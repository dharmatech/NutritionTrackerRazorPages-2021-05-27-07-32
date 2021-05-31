using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.ComplexFoodComponents
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
        ViewData["ComplexFoodId"] = new SelectList(_context.ComplexFoods, "Id", "Name");
        ViewData["SimpleFoodId"] = new SelectList(_context.SimpleFoods, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ComplexFoodComponent ComplexFoodComponent { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ComplexFoodComponents.Add(ComplexFoodComponent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexGrouped");
        }
    }
}







