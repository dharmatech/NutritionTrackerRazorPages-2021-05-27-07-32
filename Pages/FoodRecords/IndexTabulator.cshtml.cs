using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodRecords
{
    public class IndexTabulatorModel : PageModel
    {
        private readonly NutritionTrackerContext _context;

        public IndexTabulatorModel(NutritionTrackerContext context)
        {
            _context = context;
        }

        public IList<FoodRecord> FoodRecord { get; set; }

        public async Task OnGetAsync()
        {
            FoodRecord = await _context.FoodRecords
                .OrderBy(foodRecord => foodRecord.Date)
                .ThenBy(foodRecord => foodRecord.Time)
                .Include(foodRecord => foodRecord.Food)
                .ThenInclude(food => (food as ComplexFood).ComplexFoodComponents)
                //.ThenInclude(complexFoodComponent => complexFoodComponent.SimpleFood)
                .ToListAsync();
        }
    }
}
