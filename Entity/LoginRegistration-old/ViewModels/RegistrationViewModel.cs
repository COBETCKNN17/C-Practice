using LoginRegistration.Models; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic; 
using System.Text.RegularExpressions;
using System; 

namespace LoginRegistration.ViewModels
{
    public class RegistrationViewModel
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [MinLength(3)]
        [Display (Name = "First Name")]
        public string FirstName {get; set;}
        
        [Required]
        [MinLength(3)]
        [Display (Name = "Last Name")]
        public string LastName {get; set;}

        [Required]
        [Display (Name = "Email")]
        public string Email {get; set;}

        [Required]
        [MinLength(8)]
        [Display (Name = "Password")]
        public string Password { get; set; }

        [NotMapped]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The Password must include one number, one letter, and one special character.")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string PasswordConfirmation { get; set;}
    }
}