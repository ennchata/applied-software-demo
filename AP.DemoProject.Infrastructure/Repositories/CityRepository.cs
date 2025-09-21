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
            //Console.WriteLine($"BEFORE UPDATE: Id={city.Id}, Population={city.Population}, CountryId={city.CountryId}");

            _context.Cities.Update(city);

            // Check the entity state
            //var entry = _context.Entry(city);
            //Console.WriteLine($"Entity State: {entry.State}");
            //Console.WriteLine($"Modified: {entry.Property(x => x.Population).IsModified}, {entry.Property(x => x.CountryId).IsModified}");

            //var changes = await _context.SaveChangesAsync();
            //Console.WriteLine($"SaveChangesAsync completed. Changes saved: {changes}");

            // Verify the changes were saved
            //var updatedCity = await _context.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == city.Id);
            //if (updatedCity != null)
            //{
                //Console.WriteLine($"AFTER SAVE: Population={updatedCity.Population}, CountryId={updatedCity.CountryId}");
            //}
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
    }
}
