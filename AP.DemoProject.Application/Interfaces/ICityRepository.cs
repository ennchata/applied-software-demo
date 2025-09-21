using AP.DemoProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.Interfaces {
    public interface ICityRepository : IGenericRepository<City> {
        Task<PagedResult<City>> GetAllSortByPopulation(int pageNr, int pageSize);
        Task<City?> GetByName(string name);
        Task<City?> GetByIdAsync(int id);
        Task UpdateAsync(City city);
        Task<int> CountAsync();
    }
}
