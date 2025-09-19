using AP.DemoProject.Domain;
using AP.DemoProject.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Contexts {
    public class DemoContext : DbContext {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<City>().Seed();
            modelBuilder.Entity<Country>().Seed();
        }
    }
}
