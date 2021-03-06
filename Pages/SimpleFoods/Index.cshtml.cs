using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoods
{
    public class IndexModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public IndexModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        public IList<SimpleFood> SimpleFood { get;set; }

        public async Task OnGetAsync()
        {
            SimpleFood = await _context.SimpleFoods
                .Include(s => s.FoodCategory).ToListAsync();
        }
    }
}








