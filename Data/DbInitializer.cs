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

            var meat = new FoodCategory() { Name = "Meat" };
            var vegetable = new FoodCategory() { Name = "Vegetable" };
            var fruit = new FoodCategory() { Name = "Fruit" };
            var legume = new FoodCategory() { Name = "Legume" };
            var grain = new FoodCategory() { Name = "Grain" };

            context.FoodCategories.AddRange(meat, vegetable, fruit, legume, grain);

            context.SaveChanges();

            var beef80  = new SimpleFood() { Name = "Ground Beef 80/20 (g)", FoodCategory = meat, ServingSize = 100, Calories = 254, Fat = 16.20m, Carbohydrates = 0, Protein = 25.30m };
            var basmati = new SimpleFood() { Name = "Basmati Rice (g)",      FoodCategory = grain, ServingSize = 45, Calories = 160, Fat = 0.5m, Carbohydrates = 36, Protein = 3 };
            var avocado = new SimpleFood() { Name = "Avocado (g)",           FoodCategory = fruit, ServingSize = 100, Calories = 167, Fat = 15.40m, Carbohydrates = 8.6m, Protein = 2 };
            var lentils = new SimpleFood() { Name = "Lentils (g)",           FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 23m, Protein = 8 };
            var lima    = new SimpleFood() { Name = "Lima Beans (g)",        FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 22m, Protein = 7 };
            var onion   = new SimpleFood() { Name = "Onion (g)",             FoodCategory = vegetable, ServingSize = 100, Calories = 40, Fat = 0.10m, Carbohydrates = 9.3m, Protein = 1.1m };
            var yam     = new SimpleFood() { Name = "Yam (g)",               FoodCategory = vegetable, ServingSize = 100, Calories = 118, Fat = 0.2m, Carbohydrates = 27.9m, Protein = 1.5m };
            var apple   = new SimpleFood() { Name = "Apple (g)",             FoodCategory = fruit, ServingSize = 100, Calories = 52, Fat = 0.2m, Carbohydrates = 13.8m, Protein = 0.3m };
            var banana  = new SimpleFood() { Name = "Banana (g)",            FoodCategory = fruit, ServingSize = 100, Calories = 89, Fat = 0.3m, Carbohydrates = 22.8m, Protein = 1.1m };


            context.SimpleFoods.AddRange(beef80, basmati, avocado, lentils, lima, onion, yam, apple, banana);

            context.SaveChanges();

            context.FoodRecords.AddRange(
                new FoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("12:00"), Food = beef80, Amount = 200 },
                new FoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("12:00"), Food = basmati, Amount = 300 },
                new FoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("12:00"), Food = avocado, Amount = 50 },
                new FoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("18:00"), Food = lentils, Amount = 250 },
                new FoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("18:00"), Food = onion, Amount = 150 },
                new FoodRecord() { Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("18:00"), Food = basmati, Amount = 350 }

                );

            context.SaveChanges();
                        
            var LimaYamOnion = new ComplexFood() 
            { 
                Name = "LimaYamOnion", 
                ServingSize = 3000,
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

            context.FoodRecords.AddRange(
                new FoodRecord() { Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("12:00"), Food = LimaYamOnion, Amount = 300 },
                new FoodRecord() { Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("18:00"), Food = LimaYamOnion, Amount = 500 }
                );

            context.SaveChanges();            
        }

    }
}
