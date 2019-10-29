using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Models;
using OdeToFood.Data.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.SqlData {
    public class SqlRestaurantData : IRestaurantData {
        private readonly OdeToFoodDbContext _dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext) {
            _dbContext = dbContext;
        }
        public RestaurantModel Add(RestaurantModel newRestaurant) {
            _dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit() {
            return _dbContext.SaveChanges();
        }

        public RestaurantModel Delete(int restaurantId) {
            var restaurant = GetById(restaurantId);
            if (restaurant != null) {
                _dbContext.RestaurantModels.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<RestaurantModel> GetAll() {
            throw new System.NotImplementedException();
        }

        public RestaurantModel GetById(int id) {
            return _dbContext.RestaurantModels.Find(id);
        }

        public int GetCountOfRestaurants() {
            return _dbContext.RestaurantModels.Count();
        }

        public IEnumerable<RestaurantModel> GetRestaurantByName(string name) {
            var restaurant = from r in _dbContext.RestaurantModels
                             where r.Name.StartsWith(name) || string.IsNullOrEmpty(name) || r.Location.StartsWith(name)
                             orderby r.Name
                             select r;
            return restaurant;
        }

        public RestaurantModel Update(RestaurantModel updatedRestaurant) {
            var entity = _dbContext.RestaurantModels.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
