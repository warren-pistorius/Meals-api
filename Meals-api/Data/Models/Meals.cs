using System;
using System.ComponentModel.DataAnnotations;

namespace Meals_api.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
