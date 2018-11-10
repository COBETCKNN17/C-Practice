using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.ViewModels
{
    public class RegistrationViewModel
    {
        [Display (Name = "First Name")]
        public string FirstName { get; set; }
        [Display (Name = "Last Name")]
        public string LastName { get; set; }
        [Display (Name = "Email")]
        public string Email { get; set; }
        [Display (Name = "Password")]
        public string Password { get; set; }

        [Display (Name = "Confirm Password")]
        [Compare("Password")]
        public string PasswordConfirmation { get; set;}
    }
}