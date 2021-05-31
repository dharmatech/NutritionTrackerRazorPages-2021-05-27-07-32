using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.ComplexFoodComponents
{
    public class IndexGroupedModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public IndexGroupedModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        public IList<ComplexFoodComponent> ComplexFoodComponent { get; set; }

        public async Task OnGetAsync()
        {
            ComplexFoodComponent = await _context.ComplexFoodComponents
                .Include(c => c.ComplexFood)
                .Include(c => c.SimpleFood).ToListAsync();
        }
    }
}







