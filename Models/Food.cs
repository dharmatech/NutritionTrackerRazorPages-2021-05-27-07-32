using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Models
{
    public abstract class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal ServingSize { get; set; }

        public abstract decimal Calories { get; set; }
        public abstract decimal Fat { get; set; }
        //public abstract decimal Cholesterol { get; set; }
        public abstract decimal Sodium { get; set; }
        public abstract decimal Carbohydrates { get; set; }
        //public abstract decimal DietaryFiber { get; set; }
        //public abstract decimal Sugar { get; set; }
        //public abstract decimal AddedSugars { get; set; }
        public abstract decimal Protein { get; set; }

        //public abstract decimal VitaminD { get; set; }
        //public abstract decimal Calcium { get; set; }
        //public abstract decimal Iron { get; set; }
        //public abstract decimal Potassium { get; set; }
        //public abstract decimal VitaminC { get; set; }

        public string Discriminator { get; set; }
    }
}
