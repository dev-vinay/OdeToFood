using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core.Enumerations;
using OdeToFood.Core.Models;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurant {
    public class EditModel : PageModel {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty]
        public RestaurantModel Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId) {
            if (restaurantId.HasValue) {
                Restaurant = _restaurantData.GetById(restaurantId.Value);
            } else {
                Restaurant = new RestaurantModel();
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost() {
            string message = string.Empty;
            if (!ModelState.IsValid) {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.Id > 0) {
                Restaurant = _restaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant Updated!!";
            } else {
                _restaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurant Saved!!";
            }
            _restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}