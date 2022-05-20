using System;
using System.Application.Contracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace System.Persistence.Repositories
{
    public class BaseRepository<T>: IAsyncRepository<T> where T: class
    {
        private readonly SystemDBContext _dbContext;

        public BaseRepository(SystemDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
           return entity;
        }
    }
}
