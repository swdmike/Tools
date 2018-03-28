using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tools.csv
{
    public sealed class BarContext:DbContext
    {
        public DbSet<Bar> Bars { get; set; }
        
        private static bool _created = false;
        public BarContext()
        {
            if (!_created)
            {
                _created = true;
                this.Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("app.config", false, true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("SqliteConnection");

            optionsBuilder.UseSqlite("Filename=" + connectionString);
        }
    }
}