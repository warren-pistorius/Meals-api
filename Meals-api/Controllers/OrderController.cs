using Meals_api.Data;
using Meals_api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Meals_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MealsContext _mealsContext;

        public OrdersController(MealsContext mealsContext)
        {
            _mealsContext = mealsContext;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Models.Checkout order)
        {
            var dbOrder = new Order
            {
                CreatedDate = System.DateTime.UtcNow,
                Address = order.Address,
                Person = order.Person,
                OrderItems = order.OrderItems.Select(s => new OrderItem
                {
                    Meal = _mealsContext.Meals.First(f => f.Id == s.Id),
                    Quantity = s.Quantity
                }).ToList()
            };


            await _mealsContext.Orders.AddAsync(dbOrder);
            await _mealsContext.SaveChangesAsync();

            var addedModel = new Models.Meal
            {
                Id = dbOrder.Id
            };

            return Created($"https://localhost/5000/order/{dbOrder.Id}", addedModel);
        }

        [Route("all")]
        [HttpGet]
        //[Produces(typeof(Order))]
        public IActionResult Get()
        {
            return Ok(_mealsContext.Orders

                .Select(s => new Models.Order
                {
                    Address = s.Address,
                    Person = s.Person,
                    OrderItems = s.OrderItems.Select(i => new Models.OrderItem
                    {
                        Id = s.Id,
                        Meal = new Models.Meal
                        {
                            Id = i.Meal.Id,
                            Name = i.Meal.Name,
                            Description = i.Meal.Description,
                            Amount = i.Meal.Amount
                        },
                        Quantity = i.Quantity
                    }).ToList()

                }).ToList());
        }
    }
}
