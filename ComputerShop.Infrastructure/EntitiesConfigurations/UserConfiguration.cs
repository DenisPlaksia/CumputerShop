using ComputerShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerShop.Infrastructure.EntitiesConfigurations;

public class UserConfiguration: BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("users");
        
        builder.Property(user => user.Name) 
            .HasColumnName("name")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(user => user.Surname)
            .HasColumnName("surname")
            .HasMaxLength(500);
        
        builder.Property(user => user.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(15)
            .IsRequired();
        
        builder.Property(user => user.Age)
            .HasColumnName("age")
            .IsRequired();

        builder.Property(user => user.Email)
            .HasColumnName("email")
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(user => user.Sex)
            .HasColumnName("sex")
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(user => user.IsAdmin)
            .HasColumnName("is_admin")
            .HasMaxLength(250)
            .IsRequired();
        
        
        builder.Property(user => user.Password)
            .HasColumnName("password")
            .HasMaxLength(250)
            .IsRequired();
    }
}