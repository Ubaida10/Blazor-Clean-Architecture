using System.Data;
using Core.Data;
using Core.Entities;

namespace Core.RepositoryInterfaces;

public interface IUserRepository
{
    public User GetUser(string email);
    public void AddUser(Register register);
    public void Edit(Register register);
    public void Delete(string email);
    public bool ValidateUser(string email, string password);
}