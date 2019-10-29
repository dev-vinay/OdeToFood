using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Models;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant {
    public class DeleteModel : PageModel {
        private readonly IRestaurantData _restaurantData;
        public RestaurantModel Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData) {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId) {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId) {
            var deletedRestaurant = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{deletedRestaurant.Name} deleted!!";
            return RedirectToPage("./List");
        }
    }
}