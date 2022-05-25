using ComputerShop.API.DTOs.Request;
using ComputerShop.Domain.Entities;
using ComputerShop.Infrastructure;

namespace ComputerShop.API.Service;

public class UserService
{
    private UnitOfWork _unitOfWork;

    public UserService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> GetUser(Guid id)
    {
        return await _unitOfWork.UserRepository.GetById(id);
    }

    public async Task<bool> CreateUser(UserCreateRequest userCreateRequest)
    {
        var user = new User()
        {
            Name = userCreateRequest.Name,
            Surname = userCreateRequest.Surname,
            PhoneNumber = userCreateRequest.PhoneNumber,
            Sex = userCreateRequest.Sex,
            Age = userCreateRequest.Age,
            Email = userCreateRequest.Email,
            Password = userCreateRequest.Password,
            IsAdmin = userCreateRequest.IsAdmin,
        };
        
        await _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    // public async Task<bool?> UpdateUser(UserUpdateRequest userUpdateRequest)
    // {
    //     var user = await _unitOfWork.UserRepository.GetById(userUpdateRequest.Id);
    //     
    //     if (user is null)
    //     {
    //         return null;
    //     }
    //
    //     user.Name = userUpdateRequest.Name;
    //     user.Surname = userUpdateRequest.Surname;
    //     user.PhoneNumber = userUpdateRequest.Phone;
    //     
    //     await _unitOfWork.UserRepository.Upsert(user);
    //     await _unitOfWork.CompleteAsync();
    //     return true;
    // }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _unitOfWork.UserRepository.GetById(id);
        await _unitOfWork.UserRepository.Delete(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}