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
            modelBuilder.HasData(
                new City() {
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
                },

                // Belgium
                new City() {
                    Id = -7,
                    Name = "Gent",
                    Population = 800000,
                    CountryId = -1
                },
                new City() {
                    Id = -8,
                    Name = "Brugge",
                    Population = 300000,
                    CountryId = -1
                },
                new City() {
                    Id = -9,
                    Name = "Leuven",
                    Population = 200000,
                    CountryId = -1
                },
                new City() {
                    Id = -10,
                    Name = "Namur",
                    Population = 150000,
                    CountryId = -1
                },
                new City() {
                    Id = -11,
                    Name = "Liège",
                    Population = 500000,
                    CountryId = -1
                },

                // France
                new City() {
                    Id = -12,
                    Name = "Marseille",
                    Population = 3000000,
                    CountryId = -2
                },
                new City() {
                    Id = -13,
                    Name = "Lyon",
                    Population = 2000000,
                    CountryId = -2
                },
                new City() {
                    Id = -14,
                    Name = "Toulouse",
                    Population = 1200000,
                    CountryId = -2
                },
                new City() {
                    Id = -15,
                    Name = "Nice",
                    Population = 900000,
                    CountryId = -2
                },
                new City() {
                    Id = -16,
                    Name = "Nantes",
                    Population = 600000,
                    CountryId = -2
                },
                new City() {
                    Id = -17,
                    Name = "Bordeaux",
                    Population = 850000,
                    CountryId = -2
                },
                new City() {
                    Id = -18,
                    Name = "Strasbourg",
                    Population = 750000,
                    CountryId = -2
                },
                new City() {
                    Id = -19,
                    Name = "Montpellier",
                    Population = 700000,
                    CountryId = -2
                },

                // Netherlands
                new City() {
                    Id = -20,
                    Name = "Rotterdam",
                    Population = 2000000,
                    CountryId = -3
                },
                new City() {
                    Id = -21,
                    Name = "The Hague",
                    Population = 1800000,
                    CountryId = -3
                },
                new City() {
                    Id = -22,
                    Name = "Utrecht",
                    Population = 1200000,
                    CountryId = -3
                },
                new City() {
                    Id = -23,
                    Name = "Eindhoven",
                    Population = 900000,
                    CountryId = -3
                },
                new City() {
                    Id = -24,
                    Name = "Groningen",
                    Population = 400000,
                    CountryId = -3
                },
                new City() {
                    Id = -25,
                    Name = "Maastricht",
                    Population = 300000,
                    CountryId = -3
                },
                new City() {
                    Id = -26,
                    Name = "Tilburg",
                    Population = 350000,
                    CountryId = -3
                },
                new City() {
                    Id = -27,
                    Name = "Leiden",
                    Population = 250000,
                    CountryId = -3
                },
                new City() {
                    Id = -28,
                    Name = "Delft",
                    Population = 150000,
                    CountryId = -3
                },
                new City() {
                    Id = -29,
                    Name = "Zwolle",
                    Population = 180000,
                    CountryId = -3
                },
                new City() {
                    Id = -30,
                    Name = "Arnhem",
                    Population = 250000,
                    CountryId = -3
                }
            );
        }
    }
}
