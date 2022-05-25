using ComputerShop.Domain.Entities;

namespace ComputerShop.Infrastructure.Repositories;

public class UserRepository: BaseRepository<User>
{
    public UserRepository(EfContext efContext) : base(efContext)
    {
        
    }
}