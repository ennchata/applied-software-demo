using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Domain;
using AP.DemoProject.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Repositories {
    public class CityRepository : GenericRepository<City>, ICityRepository {
        public CityRepository(DemoContext context) : base(context) {
            
        }
    }
}
