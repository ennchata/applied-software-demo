using AP.BTP.Application.Interfaces;
using AP.DemoProject.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Repositories {
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext) {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<PagedResult<T>> GetAll(int pageNr, int pageSize) {
            int skipPosition = (pageNr - 1) * pageSize;
            int totalRecordCount = await _dbSet.CountAsync();

            List<T> data = await _dbSet
                .Skip(skipPosition)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<T>() {
                Data = data,
                PageNumber = pageNr,
                PageSize = pageSize,
                TotalRecordCount = totalRecordCount,
                FilteredRecordCount = totalRecordCount, // no filtering, so the same value
                TotalNumberOfPages = (int)Math.Ceiling(totalRecordCount / (double)pageSize)
            };
        }

        public async Task<T?> GetById(int id) {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Create(T newObject) {
            await _dbSet.AddAsync(newObject);
            return newObject;
        }

        public async Task<T> Update(T modifiedObject) {
            _dbSet.Update(modifiedObject);
            return await Task.FromResult(modifiedObject);
        }

        public async Task Delete(T theObject) {
            _dbSet.Remove(theObject);
            await Task.CompletedTask;
        }
    }
}
