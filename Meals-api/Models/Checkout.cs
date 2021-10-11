using System.Collections.Generic;

namespace Meals_api.Models
{
    public class Checkout
    {
        public string Person { get; set; }
        public string Address { get; set; }
        public IList<CheckoutItem> OrderItems { get; set; }
    }
}
