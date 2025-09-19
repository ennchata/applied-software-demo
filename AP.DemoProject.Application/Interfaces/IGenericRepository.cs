using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.Interfaces {
    public interface IGenericRepository<T> {
        Task<PagedResult<T>> GetAll(int pageNr, int pageSize);
        Task<T?> GetById(int id);
        Task<T> Create(T newStore);
        Task<T> Update(T modifiedStore);
        Task Delete(T store);
    }
}
