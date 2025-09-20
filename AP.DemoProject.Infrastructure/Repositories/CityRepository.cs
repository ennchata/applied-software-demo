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

        public async Task<PagedResult<City>> GetAllSortByPopulation(int pageNr, int pageSize) {
            int skipPosition = (pageNr - 1) * pageSize;
            int totalRecordCount = await _dbSet.CountAsync();

            List<City> data = await _dbSet.OrderBy(c => c.Population).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<City>() {
                Data = data,
                PageNumber = pageNr,
                PageSize = pageSize,
                TotalRecordCount = totalRecordCount,
                FilteredRecordCount = totalRecordCount,
                TotalNumberOfPages = (int)Math.Ceiling(totalRecordCount / (double)pageSize)
            };
        }

        public async Task<City?> GetByName(string name) {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
