using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridMvc;
using GridMvc.Server;
using GridShared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Data;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Pages.FoodRecords
{
    public class IndexGridBlazorModel : PageModel
    {
        private readonly NutritionTrackerContext _context;

        public IndexGridBlazorModel(NutritionTrackerContext context)
        {
            _context = context;
        }

        public IList<FoodRecord> FoodRecord { get; set; }

        public SGrid<FoodRecord> grid;

        public async Task OnGetAsync()
        {
            FoodRecord = await _context.FoodRecords
                .OrderBy(foodRecord => foodRecord.Date)
                .ThenBy(foodRecord => foodRecord.Time)
                .Include(foodRecord => foodRecord.Food)
                .ThenInclude(food => (food as ComplexFood).ComplexFoodComponents)
                //.ThenInclude(complexFoodComponent => complexFoodComponent.SimpleFood)
                .ToListAsync();

            Action<IGridColumnCollection<FoodRecord>> columns = col => 
            {
                col.Add(foodRecord => foodRecord.Date);
                col.Add(foodRecord => foodRecord.Time);
                col.Add(foodRecord => foodRecord.Food.Name);
                col.Add(foodRecord => foodRecord.Amount);
                
                col.Add(foodRecord => foodRecord.Calories);
                col.Add(foodRecord => foodRecord.Fat);
                col.Add(foodRecord => foodRecord.MonounsaturatedFat);
                col.Add(foodRecord => foodRecord.PolyunsaturatedFat);
                col.Add(foodRecord => foodRecord.Omega3);
                col.Add(foodRecord => foodRecord.Omega6);
                col.Add(foodRecord => foodRecord.SaturatedFat);
                col.Add(foodRecord => foodRecord.TransFat);
                col.Add(foodRecord => foodRecord.Cholesterol);
                col.Add(foodRecord => foodRecord.Carbohydrates);
                col.Add(foodRecord => foodRecord.Fiber);
                col.Add(foodRecord => foodRecord.SolubleFiber);
                col.Add(foodRecord => foodRecord.InsolubleFiber);
                col.Add(foodRecord => foodRecord.Starch);
                col.Add(foodRecord => foodRecord.Sugars);
                col.Add(foodRecord => foodRecord.AddedSugars);
                col.Add(foodRecord => foodRecord.Protein);
                col.Add(foodRecord => foodRecord.VitaminB1);
                col.Add(foodRecord => foodRecord.VitaminB2);
                col.Add(foodRecord => foodRecord.VitaminB3);
                col.Add(foodRecord => foodRecord.VitaminB5);
                col.Add(foodRecord => foodRecord.VitaminB6);
                col.Add(foodRecord => foodRecord.VitaminB12);
                col.Add(foodRecord => foodRecord.Folate);
                col.Add(foodRecord => foodRecord.VitaminA);
                col.Add(foodRecord => foodRecord.VitaminC);
                col.Add(foodRecord => foodRecord.VitaminD);
                col.Add(foodRecord => foodRecord.VitaminE);
                col.Add(foodRecord => foodRecord.VitaminK);
                col.Add(foodRecord => foodRecord.Calcium);
                col.Add(foodRecord => foodRecord.Copper);
                col.Add(foodRecord => foodRecord.Iron);
                col.Add(foodRecord => foodRecord.Magnesium);
                col.Add(foodRecord => foodRecord.Manganese);
                col.Add(foodRecord => foodRecord.Phosphorus);
                col.Add(foodRecord => foodRecord.Potassium);
                col.Add(foodRecord => foodRecord.Selenium);
                col.Add(foodRecord => foodRecord.Sodium);
                col.Add(foodRecord => foodRecord.Zinc);
            };

            var server = new GridServer<FoodRecord>(FoodRecord, Request.Query, false, "abcGrid", columns);

            grid = server.Grid;

            server.Groupable(true);

        }
    }
}
