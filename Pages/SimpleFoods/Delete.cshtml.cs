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
    public class DeleteModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public DeleteModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SimpleFood SimpleFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SimpleFood = await _context.SimpleFoods
                .Include(s => s.FoodCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (SimpleFood == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SimpleFood = await _context.SimpleFoods.FindAsync(id);

            if (SimpleFood != null)
            {
                _context.SimpleFoods.Remove(SimpleFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}








