using AP.DemoProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Extensions {
    public static class CountrySeeding {
        public static void Seed(this EntityTypeBuilder<Country> modelBuilder) {
            modelBuilder.HasData(new Country() {
                Id = -1,
                Name = "Belgium"
            },
            new Country() {
                Id = -2,
                Name = "France"
            },
            new Country() {
                Id = -3,
                Name = "Netherlands"
            });
        }
    }
}
