using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucure.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T enitity)
        {
            await _dbContext.Set<T>().AddAsync(enitity);
            return enitity;
        }

        public Task DeleteAsync(T enitity)
        {
            _dbContext.Set<T>().Remove(enitity);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T enitity)
        {
            _dbContext.Entry(enitity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
