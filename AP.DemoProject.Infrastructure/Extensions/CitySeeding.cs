using AP.DemoProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Extensions {
    public static class CitySeeding {
        public static void Seed(this EntityTypeBuilder<City> modelBuilder) {
            modelBuilder.HasData(new City() {
                Id = -1,
                Name = "Antwerpen",
                Population = 1000000,
                CountryId = -1
            },
            new City() {
                Id = -2,
                Name = "Brussel",
                Population = 1500000,
                CountryId = -1
            },
            new City() {
                Id = -3,
                Name = "Paris",
                Population = 6500000,
                CountryId = -2
            },
            new City() {
                Id = -4,
                Name = "Lille",
                Population = 750000,
                CountryId = -2
            },
            new City() {
                Id = -5,
                Name = "Amsterdam",
                Population = 2300000,
                CountryId = -3
            },
            new City() {
                Id = -6,
                Name = "Breda",
                Population = 12500,
                CountryId = -3
            });
        }
    }
}
