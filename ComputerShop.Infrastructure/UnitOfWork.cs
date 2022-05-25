using ComputerShop.Infrastructure.Repositories;

namespace ComputerShop.Infrastructure;

public class UnitOfWork
{
    private EfContext _efContext;
    public UserRepository UserRepository => new UserRepository(_efContext);

    public UnitOfWork(EfContext efContext)
    {
        _efContext = efContext;
    }
    
    public async Task CompleteAsync()
    {
        await _efContext.SaveChangesAsync();
    }
    public void Dispose()
    {
        _efContext.Dispose();
    }
}