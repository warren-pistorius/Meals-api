using System.Collections.Generic;

namespace Meals_api.Models
{
    public class Order
    {
        public string Person { get; set; }
        public string Address {  get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
