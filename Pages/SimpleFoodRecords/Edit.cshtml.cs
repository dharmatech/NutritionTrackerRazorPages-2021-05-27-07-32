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

namespace NutritionTrackerRazorPages.Pages.SimpleFoodRecords
{
    public class EditModel : PageModel
    {
        private readonly NutritionTrackerRazorPages.Data.NutritionTrackerContext _context;

        public EditModel(NutritionTrackerRazorPages.Data.NutritionTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SimpleFoodRecord SimpleFoodRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SimpleFoodRecord = await _context.SimpleFoodRecords
                .Include(s => s.Food).FirstOrDefaultAsync(m => m.Id == id);

            if (SimpleFoodRecord == null)
            {
                return NotFound();
            }
           ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Discriminator");
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

            _context.Attach(SimpleFoodRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimpleFoodRecordExists(SimpleFoodRecord.Id))
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

        private bool SimpleFoodRecordExists(int id)
        {
            return _context.SimpleFoodRecords.Any(e => e.Id == id);
        }
    }
}
