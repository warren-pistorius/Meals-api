using Meals_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Meals_api.Data
{
    public class MealsContext : DbContext
    {
        public MealsContext(DbContextOptions<MealsContext> options) : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
