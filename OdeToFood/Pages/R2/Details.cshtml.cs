﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly OdeToFood.Data.DataContext.OdeToFoodDbContext _context;

        public DetailsModel(OdeToFood.Data.DataContext.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public RestaurantModel RestaurantModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RestaurantModel = await _context.RestaurantModels.FirstOrDefaultAsync(m => m.Id == id);

            if (RestaurantModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
