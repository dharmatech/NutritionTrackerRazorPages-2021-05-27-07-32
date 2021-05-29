using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class SimpleFoodRecord : FoodRecord
    {
        //public int Id { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime Date { get; set; }

        //[DataType(DataType.Time)]
        //public DateTime Time { get; set; }

        //public int SimpleFoodId { get; set; }
        //public SimpleFood SimpleFood { get; set; } // navigation

        //public decimal Amount { get; set; }
                        
        //[ValidateNever] 
        //public override decimal Calories
        //{
        //    get { return Amount / SimpleFood.ServingSize * SimpleFood.Calories; }
        //    set { }
        //}
            
        //[ValidateNever] public decimal Fat           => Amount / SimpleFood.ServingSize * SimpleFood.Fat;
        //[ValidateNever] public decimal Carbohydrates => Amount / SimpleFood.ServingSize * SimpleFood.Carbohydrates;
        //[ValidateNever] public decimal Protein       => Amount / SimpleFood.ServingSize * SimpleFood.Protein;
    }
}
