namespace Meals_api.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Meal Meal { get; set; }

        public int Quantity { get; set; }
    }
}
