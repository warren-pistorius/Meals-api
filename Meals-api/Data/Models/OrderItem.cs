using System.ComponentModel.DataAnnotations;

namespace Meals_api.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        [Required]
        public Meal Meal { get; set; }

        public int Quantity { get; set; }
    }
}
