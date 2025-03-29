using Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();


/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AplicationDBContext>();
    context.Database.Migrate();
}*/

app.MapGet("/api", () => "Hello World!");
app.MapGet("/api/client", async (AplicationDBContext db) =>
{
    return await db.clients.ToListAsync();
});

app.MapGet("/api/client/{id:int}", async (int id, AplicationDBContext db) =>
{
    USClient? cl = await db.clients.FirstOrDefaultAsync(c => c.id == id);
    if (cl == null)
    {
        return Results.NotFound(new { Message = $"'{id}' not found" });
    }

    return Results.Ok(cl);
});

app.MapDelete("/api/client/{id:int}", async (int id, AplicationDBContext db) =>
{
    USClient? deleted = await db.clients.FirstOrDefaultAsync(c => c.id == id);
    if (deleted == null)
    {

        return Results.NotFound(new { Message = $"'{id}' not found" });
    }
    db.clients.Remove(deleted);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


app.MapPost("/api/client", async (USClient cl, AplicationDBContext db) =>
{
    cl.id = 0;
    if (string.IsNullOrEmpty(cl.name))
    {
        return Results.BadRequest(new { Message = "'name' must be not empty string" });
    }
    if (string.IsNullOrEmpty(cl.email))
    {
        return Results.BadRequest(new { Message = "'email' must be not empty string" });
    }
    if (cl.age < 18)
    {
        return Results.BadRequest(new { Message = "'age' must be greater  then 18" });
    }

    await db.clients.AddAsync(cl);
    await db.SaveChangesAsync();

    return Results.Ok(cl);
});

app.MapPatch("/api/client/{id:int}", async (int id, USClient cl, AplicationDBContext db) =>
{
    USClient? updated = await db.clients.FirstOrDefaultAsync(c => c.id == id);
    if (updated == null)
    {
        return Results.NotFound(new { Message = $"'{id}' not found" });
    }

    if (string.IsNullOrEmpty(cl.name))
    {
        return Results.BadRequest(new { Message = "'name' must be not empty string" });
    }
    if (string.IsNullOrEmpty(cl.email))
    {
        return Results.BadRequest(new { Message = "'email' must be not empty string" });
    }
    if (cl.age < 18)
    {
        return Results.BadRequest(new { Message = "'age' must be greater  then 18" });
    }
    updated.name = cl.name;
    updated.email = cl.email;
    updated.age = cl.age;
    
    await db.SaveChangesAsync();

    return Results.Ok(updated);
});

app.Run();
