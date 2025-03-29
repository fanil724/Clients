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


    }
}
