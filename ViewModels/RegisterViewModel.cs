using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace EmployeeManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        [ValidEmailDomain(allowedDomain:"kereu.com", ErrorMessage="Email domain name must be kereu.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
