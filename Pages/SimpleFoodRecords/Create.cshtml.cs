using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoodRecords
{
    public class CreateModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public CreateModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Discriminator");
            return Page();
        }

        [BindProperty]
        public SimpleFoodRecord SimpleFoodRecord { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SimpleFoodRecords.Add(SimpleFoodRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
