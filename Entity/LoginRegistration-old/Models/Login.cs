using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models {
    public class Login {
        public User User { get; set; }

        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [NotMapped]
        [Required]
        [MinLength (8)]
        public string Password { get; set; }

    }
}