using Meals_api.Data;
using Meals_api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meals_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly MealsContext _mealsContext;

        public MealsController(MealsContext mealsContext)
        {
            _mealsContext = mealsContext;
        }

        [Route("all")]
        [HttpGet]
        [Produces(typeof(IList<Models.Meal>))]
        public IActionResult Get()
        {
            return Ok(_mealsContext.Meals.Select(s => new Models.Meal
            {
                Id = s.Id,
                Amount = s.Amount,
                Name = s.Name,
                Description = s.Description
            }).ToList());
        }

        [Route("{id}")]
        [HttpGet]
        [Produces(typeof(Models.Meal))]
        public IActionResult Get(int id)
        {
            return Ok(_mealsContext.Meals.Select(s => new Models.Meal
            {
                Id = s.Id,
                Amount = s.Amount,
                Name = s.Name,
                Description = s.Description
            }).FirstOrDefault(f => f.Id == id));
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Models.Meal meal)
        {
            var mealToSave = new Meal
            {
                Amount = meal.Amount,
                CreatedDate = System.DateTime.UtcNow,
                Description = meal.Description,
                Name = meal.Name
            };


            await _mealsContext.Meals.AddAsync(mealToSave);
            await _mealsContext.SaveChangesAsync();

            var addedModel = new Models.Meal
            {
                Id = mealToSave.Id,
                Amount = meal.Amount,
                Name = meal.Name,
                Description = meal.Description
            };

            return Created($"https://localhost/5000/meals/{meal.Id}", addedModel);
        }
    }
}
