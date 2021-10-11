using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meals_api.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public ICollection<OrderItem> OrderItems { get; set; }

        [Required]
        public string Person { get; set; }

        [Required]
        public string Address {  get; set; }
    }
}
