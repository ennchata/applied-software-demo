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
            throw new NotImplementedException();
        }
    }
}
