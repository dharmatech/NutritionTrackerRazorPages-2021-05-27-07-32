using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class SimpleFood
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; } // navigation property

        public decimal ServingSize { get; set; }

        public decimal Calories { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Protein { get; set; }
    }
}
