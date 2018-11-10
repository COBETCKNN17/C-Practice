using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 
using System.Collections.Generic; 
using System.Text.RegularExpressions;
using System; 

namespace LoginRegistration.Models 
{
    public class User 
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [MinLength(3)]
        public string FirstName {get; set;}
        
        [Required]
        [MinLength(3)]
        public string LastName {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [NotMapped]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The Password must include one number, one letter, and one special character.")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        
        public DateTime CreatedAt {get; set;}
        public DateTime UpdtedAt {get; set;}

    }
}