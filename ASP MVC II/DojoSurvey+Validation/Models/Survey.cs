using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey_Validation.Models {
    public class Survey {
        [Required]
        [MinLength (2, ErrorMessage = "User Name must have a minimum of 2 characters")]
        [MaxLength (15, ErrorMessage = "User Name must have a maximum of 15 characters")]
        public string Username { get; set; }

        [Required] public string Location { get; set; }
        [Required] public string Language { get; set; }

        [MinLength (2, ErrorMessage = "If provided, comments must have a minimum of 2 characters")]
        public string Comments { get; set; }

    }
}