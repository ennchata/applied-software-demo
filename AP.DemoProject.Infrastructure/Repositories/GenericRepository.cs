using AP.DemoProject.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Repositories {
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext) {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll(int pageNr, int pageSize) {
            return await _dbSet.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
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
