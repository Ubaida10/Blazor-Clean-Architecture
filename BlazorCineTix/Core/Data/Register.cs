using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Identity;

namespace Core.Data;

public class Register
{
    public int Id { get; set; }

    [Display(Name = "Full name")]
    public string FullName { get; set; }

    [Display(Name = "Email address")]
    public string EmailAddress { get; set; }
    
    public string Password { get; set; }
}