using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Domain;
using AP.DemoProject.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Repositories {
    public class CountryRepository : GenericRepository<Country>, ICountryRepository {
        public CountryRepository(DemoContext context) : base(context) {
            
        }
    }
}
