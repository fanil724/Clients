using Microsoft.EntityFrameworkCore;

namespace Client
{
    public class AplicationDBContext : DbContext
    {
        public required DbSet<USClient> clients { get; set; }

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options)
       : base(options)
        {
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
             string useConnection = config["UseConnection"] ?? "DefaultConnection";
             string? connectionString = config.GetConnectionString(useConnection);
             optionsBuilder.UseNpgsql(connectionString);
         }*/
    }
}
