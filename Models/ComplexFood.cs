using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFood : Food
    {
        public List<ComplexFoodComponent> ComplexFoodComponents { get; set; } // navigation
        
        [ValidateNever]
        public override decimal Calories 
        {
            get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Calories);
            //get => ComplexFoodComponents.Sum(component => component.Calories);
            set { }
        }

        [ValidateNever] 
        public override decimal Fat
        {
            get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Fat);
            set { }
        }

        [ValidateNever]
        public override decimal Sodium
        {
            get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Sodium);
            set { }
        }

        [ValidateNever] 
        public override decimal Carbohydrates
        {
            get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Carbohydrates);
            set { }
        }
        
        [ValidateNever] 
        public override decimal Protein
        {
            get => ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Protein);
            set { }
        }
    }
}
