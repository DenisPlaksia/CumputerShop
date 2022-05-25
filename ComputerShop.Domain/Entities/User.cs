using ComputerShop.Domain.Base;

namespace ComputerShop.Domain.Entities;

public class User: IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public byte Age { get; set; }
    public byte PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}