using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.SimpleFoods
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
        ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public SimpleFood SimpleFood { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SimpleFoods.Add(SimpleFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}








