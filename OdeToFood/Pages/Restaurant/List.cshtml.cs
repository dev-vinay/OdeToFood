using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core.Models;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurent {
    public class ListModel : PageModel {

        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;

        public string MessageFromAppSetting = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<RestaurantModel> Restaurants { get; set; }
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData) {
            MessageFromAppSetting = configuration["Message"];

            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }
        public void OnGet() {
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}
