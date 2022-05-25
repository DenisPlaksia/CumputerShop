using ComputerShop.API.DTOs.Request;
using ComputerShop.API.Service;
using ComputerShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.API.Controllers;

[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<User> GetUser([FromRoute] Guid id)
    {
        return await _userService.GetUser(id);
    }
    
    [HttpPost]
    public async Task<bool> CreateUser(UserCreateRequest user)
    {
        return await _userService.CreateUser(user);
    }

    // [HttpPut]
    // public async Task<bool> UpdateUser(UserUpdateRequest userUpdateRequest)
    // {
    //     await _userService.UpdateUser(userUpdateRequest);
    //     return true;
    // }
    
    [HttpDelete("{id}")]
    public async Task<bool> DeleteUser([FromRoute] Guid id)
    {
        await _userService.DeleteUser(id);
        return true;
    }
}