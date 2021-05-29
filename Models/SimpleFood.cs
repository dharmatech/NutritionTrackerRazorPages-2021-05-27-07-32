using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class SimpleFood : Food
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; } // navigation property

        //public decimal ServingSize { get; set; }

        public override decimal Calories { get; set; }
        public override decimal Fat { get; set; }
        public override decimal Carbohydrates { get; set; }
        public override decimal Protein { get; set; }
    }
}
