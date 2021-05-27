using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoodRecords
{
    public class DetailsModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public DetailsModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        public SimpleFoodRecord SimpleFoodRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SimpleFoodRecord = await _context.SimpleFoodRecords
                .Include(s => s.SimpleFood).FirstOrDefaultAsync(m => m.Id == id);

            if (SimpleFoodRecord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}







