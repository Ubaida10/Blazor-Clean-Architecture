using System.Data;
using Core.Data;
using Core.Entities;

namespace Application.ServicesInterfaces;

public interface IUserService
{
    public User GetUser(string email);
    public void AddUser(Register register);
    public void EditUser(Register register);
    public void DeleteUser(string id);
    public bool ValidateUser(string email, string password);
}