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

        public DbSet<FoodCategory>         FoodCategories        { get; set; }

        public DbSet<Food>                 Foods                 { get; set; }
        public DbSet<FoodRecord>           FoodRecords           { get; set; }

        public DbSet<SimpleFood>           SimpleFoods           { get; set; }
        
        public DbSet<ComplexFood>          ComplexFoods          { get; set; }
        public DbSet<ComplexFoodComponent> ComplexFoodComponents { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodCategory>()        .ToTable(nameof(FoodCategory));
            modelBuilder.Entity<FoodRecord>()          .ToTable(nameof(FoodRecord));
            modelBuilder.Entity<ComplexFoodComponent>().ToTable(nameof(ComplexFoodComponent));
        }

    }
}
