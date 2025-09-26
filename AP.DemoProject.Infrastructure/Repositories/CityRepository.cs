using AP.BTP.Application;
using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.DemoProject.Application;
using AP.DemoProject.Infrastructure.Contexts;
using AP.DemoProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository {

        private readonly DemoContext _context;
        public CityRepository(DemoContext context) : base(context) {
            _context = context;
        }
        public async Task<City?> GetByIdAsync(int id)
        {
            return await _context.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
        }
        
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
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
