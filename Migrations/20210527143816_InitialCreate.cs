﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionTrackerRazorPages.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplexFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexFood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplexFoodRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ComplexFoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexFoodRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplexFoodRecord_ComplexFood_ComplexFoodId",
                        column: x => x.ComplexFoodId,
                        principalTable: "ComplexFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimpleFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FoodCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServingSize = table.Column<decimal>(type: "TEXT", nullable: false),
                    Calories = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fat = table.Column<decimal>(type: "TEXT", nullable: false),
                    Carbohydrates = table.Column<decimal>(type: "TEXT", nullable: false),
                    Protein = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimpleFood_FoodCategory_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplexFoodComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComplexFoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    SimpleFoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexFoodComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplexFoodComponent_ComplexFood_ComplexFoodId",
                        column: x => x.ComplexFoodId,
                        principalTable: "ComplexFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplexFoodComponent_SimpleFood_SimpleFoodId",
                        column: x => x.SimpleFoodId,
                        principalTable: "SimpleFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimpleFoodRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SimpleFoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleFoodRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimpleFoodRecord_SimpleFood_SimpleFoodId",
                        column: x => x.SimpleFoodId,
                        principalTable: "SimpleFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplexFoodComponent_ComplexFoodId",
                table: "ComplexFoodComponent",
                column: "ComplexFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplexFoodComponent_SimpleFoodId",
                table: "ComplexFoodComponent",
                column: "SimpleFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplexFoodRecord_ComplexFoodId",
                table: "ComplexFoodRecord",
                column: "ComplexFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleFood_FoodCategoryId",
                table: "SimpleFood",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleFoodRecord_SimpleFoodId",
                table: "SimpleFoodRecord",
                column: "SimpleFoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplexFoodComponent");

            migrationBuilder.DropTable(
                name: "ComplexFoodRecord");

            migrationBuilder.DropTable(
                name: "SimpleFoodRecord");

            migrationBuilder.DropTable(
                name: "ComplexFood");

            migrationBuilder.DropTable(
                name: "SimpleFood");

            migrationBuilder.DropTable(
                name: "FoodCategory");
        }
    }
}
