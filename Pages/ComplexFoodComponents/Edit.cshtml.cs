using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.ComplexFoodComponents
{
    public class EditModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public EditModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ComplexFoodComponent ComplexFoodComponent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ComplexFoodComponent = await _context.ComplexFoodComponents
                .Include(c => c.ComplexFood)
                .Include(c => c.SimpleFood).FirstOrDefaultAsync(m => m.Id == id);

            if (ComplexFoodComponent == null)
            {
                return NotFound();
            }
           ViewData["ComplexFoodId"] = new SelectList(_context.ComplexFoods, "Id", "Id");
           ViewData["SimpleFoodId"] = new SelectList(_context.SimpleFoods, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ComplexFoodComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexFoodComponentExists(ComplexFoodComponent.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ComplexFoodComponentExists(int id)
        {
            return _context.ComplexFoodComponents.Any(e => e.Id == id);
        }
    }
}







