using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public class ComplexFoodRecord
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public int ComplexFoodId { get; set; }
        public ComplexFood ComplexFood { get; set; } // navigation

        public decimal Amount { get; set; }

        [ValidateNever] public decimal Calories      => Amount / ComplexFood.Amount * ComplexFood.Calories;
        [ValidateNever] public decimal Fat           => Amount / ComplexFood.Amount * ComplexFood.Fat;
        [ValidateNever] public decimal Carbohydrates => Amount / ComplexFood.Amount * ComplexFood.Carbohydrates;
        [ValidateNever] public decimal Protein       => Amount / ComplexFood.Amount * ComplexFood.Protein;
    }
}
