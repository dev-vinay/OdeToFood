using OdeToFood.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core.Models {
    public class RestaurantModel {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        [Required]
        public CuisineType Cuisines { get; set; }
    }

}
