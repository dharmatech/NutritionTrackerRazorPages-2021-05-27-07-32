using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFoodComponent
    {
        public int         Id            { get; set; }
        public int         ComplexFoodId { get; set; }
        public ComplexFood ComplexFood   { get; set; } // navigation
        public int         SimpleFoodId  { get; set; }
        public SimpleFood  SimpleFood    { get; set; } // navigation
        public decimal     Amount        { get; set; }

        [ValidateNever] public decimal Calories      => Amount / SimpleFood.ServingSize * SimpleFood.Calories;
        [ValidateNever] public decimal Fat           => Amount / SimpleFood.ServingSize * SimpleFood.Fat;
        [ValidateNever] public decimal Carbohydrates => Amount / SimpleFood.ServingSize * SimpleFood.Carbohydrates;
        [ValidateNever] public decimal Protein       => Amount / SimpleFood.ServingSize * SimpleFood.Protein;
    }
}
