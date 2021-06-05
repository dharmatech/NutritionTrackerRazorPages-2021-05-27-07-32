﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionTrackerRazorPages.Data;

namespace NutritionTrackerRazorPages.Migrations
{
    [DbContext(typeof(NutritionTrackerContext))]
    [Migration("20210601232751_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFoodComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("ComplexFoodId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SimpleFoodId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ComplexFoodId");

                    b.HasIndex("SimpleFoodId");

                    b.ToTable("ComplexFoodComponent");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AddedSugars")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Calcium")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Calories")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cholesterol")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Copper")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fat")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fiber")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Folate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InsolubleFiber")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Iron")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Magnesium")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Manganese")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MonounsaturatedFat")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Omega3")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Omega6")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Phosphorus")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PolyunsaturatedFat")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Potassium")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Protein")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SaturatedFat")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Selenium")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ServingSize")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sodium")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SolubleFiber")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Starch")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sugars")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TransFat")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminA")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminB1")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminB12")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminB2")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminB3")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminB5")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminB6")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminC")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminD")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminE")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("VitaminK")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Zinc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Food");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FoodCategory");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.FoodRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("FoodId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodRecord");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFood", b =>
                {
                    b.HasBaseType("NutritionTrackerRazorPages.Models.Food");

                    b.HasDiscriminator().HasValue("ComplexFood");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.SimpleFood", b =>
                {
                    b.HasBaseType("NutritionTrackerRazorPages.Models.Food");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("FoodCategoryId");

                    b.HasDiscriminator().HasValue("SimpleFood");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFoodComponent", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.ComplexFood", "ComplexFood")
                        .WithMany("ComplexFoodComponents")
                        .HasForeignKey("ComplexFoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutritionTrackerRazorPages.Models.SimpleFood", "SimpleFood")
                        .WithMany()
                        .HasForeignKey("SimpleFoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComplexFood");

                    b.Navigation("SimpleFood");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.FoodRecord", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.SimpleFood", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.FoodCategory", "FoodCategory")
                        .WithMany()
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFood", b =>
                {
                    b.Navigation("ComplexFoodComponents");
                });
#pragma warning restore 612, 618
        }
    }
}