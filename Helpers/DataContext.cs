using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using keknani_server.Entities;

namespace keknani_server.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("keknani_serverDatabase"));
        }
    }
}