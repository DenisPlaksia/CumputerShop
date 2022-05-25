using ComputerShop.Domain.Base;
using ComputerShop.Domain.Entities;
using ComputerShop.Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Infrastructure;

public class EfContext: DbContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        CheckEntityState();
        
        return base.SaveChangesAsync(cancellationToken);        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=ComputerShop;username=student;password=admin");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfiguration().Configure(modelBuilder.Entity<User>());   
    }
    
    private void CheckEntityState()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var baseEntity = entry.Entity as IBaseEntity;
            if (baseEntity == null)
            {
                continue;
            }
            
            if (entry.State == EntityState.Added)
            {
                baseEntity.Id = Guid.NewGuid();
                baseEntity.CreateDate = DateTime.UtcNow;
                baseEntity.UpdateDate = DateTime.UtcNow;
                baseEntity.DeleteDate = null;
                baseEntity.IsDeleted = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdateDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.UpdateDate = DateTime.UtcNow;
                baseEntity.DeleteDate = DateTime.UtcNow;
                baseEntity.IsDeleted = true;
            }
        }
    }
}