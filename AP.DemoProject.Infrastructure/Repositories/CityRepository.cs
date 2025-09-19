using AP.DemoProject.Application;
using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Domain;
using AP.DemoProject.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Repositories {
    public class CityRepository : GenericRepository<City>, ICityRepository {
        public CityRepository(DemoContext context) : base(context) {
            
        }

        public async Task<IEnumerable<City>> GetAllSortByPopulation(int pageNr, int pageSize) {
            return await _dbSet.OrderBy(c => c.Population).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
