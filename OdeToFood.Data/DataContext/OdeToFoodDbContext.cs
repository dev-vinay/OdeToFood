using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Models;

namespace OdeToFood.Data.DataContext {
    public class OdeToFoodDbContext : DbContext {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options) {

        }
        public DbSet<RestaurantModel> RestaurantModels { get; set; }
    }
}
 