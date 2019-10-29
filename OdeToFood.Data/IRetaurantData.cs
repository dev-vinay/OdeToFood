using OdeToFood.Core.Enumerations;
using OdeToFood.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data {
    public interface IRestaurantData {
        IEnumerable<RestaurantModel> GetAll();
        IEnumerable<RestaurantModel> GetRestaurantByName(string name);
        RestaurantModel GetById(int id);
        RestaurantModel Update(RestaurantModel updatedRestaurant);
        RestaurantModel Add(RestaurantModel newRestaurant);
        RestaurantModel Delete(int restaurantId);
        int GetCountOfRestaurants();
        int Commit();
    }
    public class InMemoryRestaurantData : IRestaurantData {
        readonly List<RestaurantModel> restaurants;

        public InMemoryRestaurantData() {
            restaurants = new List<RestaurantModel>() {
            new RestaurantModel{Id = 1,Name="vinay' pizza",Location="Pune",Cuisines=CuisineType.Italian },
            new RestaurantModel{Id = 2,Name="Chicken Cornet",Location="Noida",Cuisines=CuisineType.Indian },
            new RestaurantModel{Id=3,Name="Famous Mughlai",Location="Delhi",Cuisines=CuisineType.Mughlai }
            };
        }
        public IEnumerable<RestaurantModel> GetAll() {
            var listOfRestaurant = from r in restaurants
                                   orderby r.Name
                                   select r;
            return listOfRestaurant;
        }
        public RestaurantModel GetById(int id) {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<RestaurantModel> GetRestaurantByName(string name = null) {
            var searchedRestaturant = from r in restaurants
                                      where string.IsNullOrEmpty(name) || r.Name.StartsWith(name) || r.Location.StartsWith(name)
                                      orderby r.Name
                                      select r;
            return searchedRestaturant;
        }
        public RestaurantModel Update(RestaurantModel updatedRestaurant) {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null) {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisines = updatedRestaurant.Cuisines;
            }
            return restaurant;
        }
        public int Commit() {
            return 0;
        }
        public RestaurantModel Add(RestaurantModel newRestaurant) {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        public RestaurantModel Delete(int restaurantId) {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant != null) {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
        public int GetCountOfRestaurants() {
            return restaurants.Count;
        }
    }
}
