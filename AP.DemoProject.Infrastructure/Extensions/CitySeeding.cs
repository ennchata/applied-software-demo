﻿using AP.DemoProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Extensions {
    public static class CitySeeding {
        public static void Seed(this EntityTypeBuilder<City> modelBuilder) {
            throw new NotImplementedException();
        }
    }
}
