using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodRecords
{
    public class CreateModel : PageModel
    {
        private readonly NutritionTrackerContext _context;

        public CreateModel(NutritionTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Name");

            FoodRecord = new FoodRecord() 
            { 
                Date = DateTime.Now,
                Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
            };
                        
            return Page();
        }

        [BindProperty]
        public FoodRecord FoodRecord { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.FoodRecords.Add(FoodRecord);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
