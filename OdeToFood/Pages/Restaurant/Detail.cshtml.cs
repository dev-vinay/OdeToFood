using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Models;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant {
    public class DetailModel : PageModel {
        private readonly IRestaurantData restaurantData;
        public RestaurantModel Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }
        //public void OnGet(int resturantId) {
        //    Restaurant = restaurantData.GetById(resturantId);
        //}

        public IActionResult OnGet(int restaurantId) {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}