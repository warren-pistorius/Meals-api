using Meals_api.Data.Models;
using Meals_api.Models;
using System.Collections.Generic;
using System.Linq;
using Meal = Meals_api.Data.Models.Meal;
using Order = Meals_api.Data.Models.Order;
using OrderItem = Meals_api.Data.Models.OrderItem;

namespace Meals_api.Data
{
    public static class MealsInitializer
    {
        public static void Initialize(MealsContext context)
        {

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            var meal = new Meal
            {
                Name = "Sushi",
                Amount = 22.99,
                CreatedDate = System.DateTime.UtcNow,
                Description = "Finest fish and veggies"
            };
            context.Meals.Add(meal);

            meal = new Meal
            {
                Name = "Schnitzel",
                Amount = 16.50,
                CreatedDate = System.DateTime.UtcNow,
                Description = "A german specialty!"
            };
            context.Meals.Add(meal);

            meal = new Meal
            {
                Name = "Barbecue Burger",
                Amount = 12.99,
                CreatedDate = System.DateTime.UtcNow,
                Description = "American, raw, meaty"
            };
            context.Meals.Add(meal);

            meal = new Meal
            {
                Name = "Green Bowl",
                Amount = 18.99,
                CreatedDate = System.DateTime.UtcNow,
                Description = "Healthy...and green..."
            };
            context.Meals.Add(meal);


            context.SaveChanges();

            var order = new Checkout()
            {
                Person = "Test Person",
                Address = "Address",
                OrderItems = new List<CheckoutItem> { new CheckoutItem { Id = 1, Quantity = 1 } }
            };

            var dbOrder = new Order
            {
                CreatedDate = System.DateTime.UtcNow,
                Address = order.Address,
                Person = order.Person,
                OrderItems = order.OrderItems.Select(s => new OrderItem
                {
                    Meal = context.Meals.First(f => f.Id == s.Id),
                    Quantity = s.Quantity
                }).ToList()
            };

            context.Orders.Add(dbOrder);

            context.SaveChanges();
        }
    }
}
