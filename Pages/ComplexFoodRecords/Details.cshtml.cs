using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.ComplexFoodRecords
{
    public class DetailsModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public DetailsModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        public ComplexFoodRecord ComplexFoodRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ComplexFoodRecord = await _context.ComplexFoodRecords
                .Include(c => c.Food).FirstOrDefaultAsync(m => m.Id == id);

            if (ComplexFoodRecord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
