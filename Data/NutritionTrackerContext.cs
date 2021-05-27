using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutritionTrackerRazorPages.Models;

namespace NutritionTrackerRazorPages.Data
{
    public class NutritionTrackerContext : DbContext
    {
        public NutritionTrackerContext (DbContextOptions<NutritionTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<NutritionTrackerRazorPages.Models.FoodCategory> FoodCategory { get; set; }

        public DbSet<NutritionTrackerRazorPages.Models.SimpleFood> SimpleFood { get; set; }

        public DbSet<NutritionTrackerRazorPages.Models.SimpleFoodRecord> SimpleFoodRecord { get; set; }

        public DbSet<NutritionTrackerRazorPages.Models.ComplexFood> ComplexFood { get; set; }

        public DbSet<NutritionTrackerRazorPages.Models.ComplexFoodComponent> ComplexFoodComponent { get; set; }

        public DbSet<NutritionTrackerRazorPages.Models.ComplexFoodRecord> ComplexFoodRecord { get; set; }
    }
}
