using AP.DemoProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Configurations {
    public class CityConfiguration : IEntityTypeConfiguration<City> {
        public void Configure(EntityTypeBuilder<City> builder) {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name)
                .IsUnique(true);
        }
    }
}
