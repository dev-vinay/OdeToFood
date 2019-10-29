using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Models;
using OdeToFood.Data.DataContext;

namespace OdeToFood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFood.Data.DataContext.OdeToFoodDbContext _context;

        public IndexModel(OdeToFood.Data.DataContext.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<RestaurantModel> RestaurantModel { get;set; }

        public async Task OnGetAsync()
        {
            RestaurantModel = await _context.RestaurantModels.ToListAsync();
        }
    }
}
