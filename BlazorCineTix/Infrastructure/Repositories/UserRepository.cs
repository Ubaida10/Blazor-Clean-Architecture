using Core.Data;
using Core.Entities;
using Core.Interfaces;
using Core.RepositoryInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

public class UserRepository:IUserRepository
{
    private readonly string _connectionString;
    public UserRepository()
    {
        _connectionString = @"Server=(localdb)\MSSQLLocalDB";
    }
    public User GetUser(string email)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Users WHERE Email = @Email";
        
            // Execute the query and return a single user based on email
            var user = connection.QuerySingleOrDefault<User>(query, new { Email = email });
        
            return user;
        }
    }

    public void AddUser(Register register)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string insertQuery = @"
            INSERT INTO Users (Email, Password, FullName, Role)
            VALUES (@Email, @Password, @FullName, @Role)";

            var parameters = new
            {
                Email = register.EmailAddress,
                Password = register.Password,
                FullName = register.FullName,
                Role = "user"
            };

            connection.Execute(insertQuery, parameters);
        }
    }

    public void Edit(Register register)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string updateQuery = @"
            UPDATE Users
            SET Email = @Email, Password = @Password, FullName = @FullName WHERE Email = @OldEmail";

            var parameters = new
            {
                Email = register.EmailAddress,
                Password = register.Password,
                FullName = register.FullName,
                OldEmail = register.EmailAddress
            };
            connection.Execute(updateQuery, parameters);
        }
    }

    public void Delete(string email)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string deleteQuery = "DELETE FROM Users WHERE Email = @Email";

            connection.Execute(deleteQuery, new { Email = email });
        }
    }

    public bool ValidateUser(string email, string password)
    {
        return false;
    }
}