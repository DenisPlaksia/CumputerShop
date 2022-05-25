namespace ComputerShop.API.DTOs.Request;

public class UserCreateRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public byte Age { get; set; }
    public byte PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}