using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFood : Food
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public List<ComplexFoodComponent> ComplexFoodComponents { get; set; } // navigation
        //public decimal ServingSize { get; set; }

        //[ValidateNever] public override decimal Calories      => ComplexFoodComponents.Sum(component => component.Calories);

        [ValidateNever]
        public override decimal Calories 
        { 
            get { return ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Calories); }
            set { }
        }

        [ValidateNever] 
        public override decimal Fat
        {
            get { return ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Fat); }
            set { }
        }
            
        
        [ValidateNever] 
        public override decimal Carbohydrates
        {
            get { return ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Carbohydrates); }
            set { }
        }
        
        [ValidateNever] 
        public override decimal Protein
        {
            get { return ComplexFoodComponents == null ? 0 : ComplexFoodComponents.Sum(component => component.Protein); }
            set { }
        }
    }
}
