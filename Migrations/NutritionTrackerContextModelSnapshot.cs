﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutritionTrackerRazorPages.Data;

namespace NutritionTrackerRazorPages.Migrations
{
    [DbContext(typeof(NutritionTrackerContext))]
    partial class NutritionTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ComplexFood");
                });

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

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FoodRecord");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FoodRecord");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.SimpleFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Calories")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fat")
                        .HasColumnType("TEXT");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Protein")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ServingSize")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("SimpleFood");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFoodRecord", b =>
                {
                    b.HasBaseType("NutritionTrackerRazorPages.Models.FoodRecord");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("ComplexFoodId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ComplexFoodId");

                    b.HasDiscriminator().HasValue("ComplexFoodRecord");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.SimpleFoodRecord", b =>
                {
                    b.HasBaseType("NutritionTrackerRazorPages.Models.FoodRecord");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT")
                        .HasColumnName("SimpleFoodRecord_Amount");

                    b.Property<int>("SimpleFoodId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("SimpleFoodId");

                    b.HasDiscriminator().HasValue("SimpleFoodRecord");
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

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.SimpleFood", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.FoodCategory", "FoodCategory")
                        .WithMany()
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFoodRecord", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.ComplexFood", "ComplexFood")
                        .WithMany()
                        .HasForeignKey("ComplexFoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComplexFood");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.SimpleFoodRecord", b =>
                {
                    b.HasOne("NutritionTrackerRazorPages.Models.SimpleFood", "SimpleFood")
                        .WithMany()
                        .HasForeignKey("SimpleFoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SimpleFood");
                });

            modelBuilder.Entity("NutritionTrackerRazorPages.Models.ComplexFood", b =>
                {
                    b.Navigation("ComplexFoodComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
