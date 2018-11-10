using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.ViewModels
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display (Name = "Email Address")]
        public string Email {get; set;}

        [Required]
        [MinLength(8)]
        [Display (Name = "Password")]
        public string Password { get; set; }
    }
}