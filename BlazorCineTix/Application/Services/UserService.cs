using System.Data;
using Application.ServicesInterfaces;
using Core.Data;
using Core.Entities;
using Core.Interfaces;
using Core.RepositoryInterfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public User GetUser(string email)
    {
        return _userRepository.GetUser(email);
    }

    public void AddUser(Register register)
    {
        _userRepository.AddUser(register);
    }

    public void EditUser(Register register)
    {
        _userRepository.Edit(register);
    }

    public void DeleteUser(string id)
    {
        _userRepository.Delete(id);
    }

    public bool ValidateUser(string email, string password)
    {
        var user = _userRepository.GetUser(email);
        if (user == null)
        {
            Console.WriteLine("NO USER");
        }

        if (password == user.Password)
        {
            Console.WriteLine("Valid User");
            return true;
        }
        
        return false;
    }
}