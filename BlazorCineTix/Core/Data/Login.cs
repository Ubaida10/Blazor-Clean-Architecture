using System.ComponentModel.DataAnnotations;

namespace Core.Data;

public class Login
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    public string Role { get; set; }
}