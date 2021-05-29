using NutritionTrackerRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NutritionTrackerContext context)
        {
            if (context.SimpleFoods.Any()) return;

            context.FoodCategories.AddRange(
                new FoodCategory() { Name = "Meat" },
                new FoodCategory() { Name = "Vegetable" },
                new FoodCategory() { Name = "Fruit" },
                new FoodCategory() { Name = "Legume" },
                new FoodCategory() { Name = "Grain" });

            context.SaveChanges();

            var meat = context.FoodCategories.Single(FoodCategory => FoodCategory.Name == "Meat");
            var vegetable = context.FoodCategories.Single(FoodCategory => FoodCategory.Name == "Meat");
            var fruit = context.FoodCategories.Single(FoodCategory => FoodCategory.Name == "Meat");
            var legume = context.FoodCategories.Single(FoodCategory => FoodCategory.Name == "Meat");
            var grain = context.FoodCategories.Single(FoodCategory => FoodCategory.Name == "Meat");
            
            context.SimpleFoods.AddRange(
                new SimpleFood() { Name = "Ground Beef 80/20 (g)", FoodCategory = meat,      ServingSize = 100, Calories = 254, Fat = 16.20m, Carbohydrates = 0,     Protein = 25.30m },
                new SimpleFood() { Name = "Basmati Rice (g)",      FoodCategory = grain,     ServingSize = 45,  Calories = 160, Fat = 0.5m,   Carbohydrates = 36,    Protein = 3 },
                new SimpleFood() { Name = "Avocado (g)",           FoodCategory = fruit,     ServingSize = 100, Calories = 167, Fat = 15.40m, Carbohydrates = 8.6m,  Protein = 2 },
                new SimpleFood() { Name = "Lentils (g)",           FoodCategory = legume,    ServingSize = 35,  Calories = 100, Fat = 0.5m,   Carbohydrates = 23m,   Protein = 8 },
                new SimpleFood() { Name = "Lima Beans (g)",        FoodCategory = legume,    ServingSize = 35,  Calories = 100, Fat = 0.5m,   Carbohydrates = 22m,   Protein = 7 },
                new SimpleFood() { Name = "Onion (g)",             FoodCategory = vegetable, ServingSize = 100, Calories = 40,  Fat = 0.10m,  Carbohydrates = 9.3m,  Protein = 1.1m },
                new SimpleFood() { Name = "Yam (g)",               FoodCategory = vegetable, ServingSize = 100, Calories = 118, Fat = 0.2m,   Carbohydrates = 27.9m, Protein = 1.5m },
                new SimpleFood() { Name = "Apple (g)",             FoodCategory = fruit,     ServingSize = 100, Calories = 52,  Fat = 0.2m,   Carbohydrates = 13.8m, Protein = 0.3m },
                new SimpleFood() { Name = "Banana (g)",            FoodCategory = fruit,     ServingSize = 100, Calories = 89,  Fat = 0.3m,   Carbohydrates = 22.8m, Protein = 1.1m }
                );

            context.SaveChanges();

            var beef80  = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Ground Beef 80/20 (g)");
            var basmati = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Basmati Rice (g)");
            var avocado = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Avocado (g)");
            var lentils = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Lentils (g)");
            var lima    = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Lima Beans (g)");
            var onion   = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Onion (g)");
            var yam     = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Yam (g)");
            var apple   = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Apple (g)");
            var banana  = context.SimpleFoods.Single(simpleFood => simpleFood.Name == "Banana (g)");

            context.SimpleFoodRecords.AddRange(
                new SimpleFoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("12:00"), SimpleFood = beef80, Amount = 200 },
                new SimpleFoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("12:00"), SimpleFood = basmati, Amount = 300 },
                new SimpleFoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("12:00"), SimpleFood = avocado, Amount = 50 },

                new SimpleFoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("18:00"), SimpleFood = lentils, Amount = 250 },
                new SimpleFoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("18:00"), SimpleFood = onion, Amount = 150 },
                new SimpleFoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("18:00"), SimpleFood = basmati, Amount = 350 }

                );

            context.SaveChanges();
                        
            var LimaYamOnion = new ComplexFood() 
            { 
                Name = "LimaYamOnion", 
                Amount = 3000,
                ComplexFoodComponents = new[] 
                { 
                    new ComplexFoodComponent() { SimpleFood = lima,  Amount = 454 },
                    new ComplexFoodComponent() { SimpleFood = yam,   Amount = 642 },
                    new ComplexFoodComponent() { SimpleFood = onion, Amount = 330 }
                }.ToList()
            };

            

            context.ComplexFoods.AddRange(
                LimaYamOnion
                );
                        
            context.ComplexFoodRecords.AddRange(
                new ComplexFoodRecord() { Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("12:00"), ComplexFood = LimaYamOnion, Amount = 300 },
                new ComplexFoodRecord() { Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("18:00"), ComplexFood = LimaYamOnion, Amount = 500 }
                );

            

            context.SaveChanges();            
        }

    }
}
