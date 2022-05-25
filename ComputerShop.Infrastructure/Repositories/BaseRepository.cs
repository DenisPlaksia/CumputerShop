using ComputerShop.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T:class
{
    protected EfContext context;
    private DbSet<T> dbSet;
    
    public BaseRepository(EfContext efContext)
    {
        context = efContext;
        dbSet = context.Set<T>();
    }
    
    public Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task<T> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return await Task.FromResult(entity);;
    }

    public async Task<bool> Delete(T entity)
    {
        dbSet.Remove(entity);
        return true;
    }

    public Task<T> Upsert(T entity)
    {
        dbSet.Update(entity);
        return Task.FromResult(entity);
    }
}