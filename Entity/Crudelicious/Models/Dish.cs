using System; 
using System.ComponentModel.DataAnnotations;

namespace Crudelicious.Models
{
    public class Dish
    {
        // auto-implemented properties need to match columns in your table
        [Key]
        public int DashId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Chef { get; set; }
        [Required]
        public int Tastiness { get; set; }
        [Required]
        public int Calories { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
