using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ComplexFoodComponent> ComplexFoodComponents { get; set; } // navigation
        public decimal Amount { get; set; }

        [ValidateNever] public decimal Calories      => ComplexFoodComponents.Sum(component => component.Calories);
        [ValidateNever] public decimal Fat           => ComplexFoodComponents.Sum(component => component.Fat);
        [ValidateNever] public decimal Carbohydrates => ComplexFoodComponents.Sum(component => component.Carbohydrates);
        [ValidateNever] public decimal Protein       => ComplexFoodComponents.Sum(component => component.Protein);
    }
}
