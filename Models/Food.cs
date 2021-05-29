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
        public abstract decimal Carbohydrates { get; set; }
        public abstract decimal Protein { get; set; }

        public string Discriminator { get; set; }
    }
}
