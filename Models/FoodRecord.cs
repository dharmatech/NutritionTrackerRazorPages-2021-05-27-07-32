using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class FoodRecord
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; } // navigation

        public decimal Amount { get; set; }

        [ValidateNever] public decimal Calories      => Amount / Food.ServingSize * Food.Calories;
        [ValidateNever] public decimal Fat           => Amount / Food.ServingSize * Food.Fat;
        [ValidateNever] public decimal Sodium        => Amount / Food.ServingSize * Food.Sodium;
        [ValidateNever] public decimal Carbohydrates => Amount / Food.ServingSize * Food.Carbohydrates;
        [ValidateNever] public decimal Protein       => Amount / Food.ServingSize * Food.Protein;
    }
}
