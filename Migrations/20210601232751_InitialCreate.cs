using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutritionTrackerRazorPages.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ServingSize = table.Column<decimal>(type: "TEXT", nullable: false),
                    Calories = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fat = table.Column<decimal>(type: "TEXT", nullable: false),
                    MonounsaturatedFat = table.Column<decimal>(type: "TEXT", nullable: false),
                    PolyunsaturatedFat = table.Column<decimal>(type: "TEXT", nullable: false),
                    Omega3 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Omega6 = table.Column<decimal>(type: "TEXT", nullable: false),
                    SaturatedFat = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransFat = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cholesterol = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sodium = table.Column<decimal>(type: "TEXT", nullable: false),
                    Carbohydrates = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fiber = table.Column<decimal>(type: "TEXT", nullable: false),
                    SolubleFiber = table.Column<decimal>(type: "TEXT", nullable: false),
                    InsolubleFiber = table.Column<decimal>(type: "TEXT", nullable: false),
                    Starch = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sugars = table.Column<decimal>(type: "TEXT", nullable: false),
                    AddedSugars = table.Column<decimal>(type: "TEXT", nullable: false),
                    Protein = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminB1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminB2 = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminB3 = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminB5 = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminB6 = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminB12 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Folate = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminA = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminC = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminD = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminE = table.Column<decimal>(type: "TEXT", nullable: false),
                    VitaminK = table.Column<decimal>(type: "TEXT", nullable: false),
                    Calcium = table.Column<decimal>(type: "TEXT", nullable: false),
                    Copper = table.Column<decimal>(type: "TEXT", nullable: false),
                    Iron = table.Column<decimal>(type: "TEXT", nullable: false),
                    Magnesium = table.Column<decimal>(type: "TEXT", nullable: false),
                    Manganese = table.Column<decimal>(type: "TEXT", nullable: false),
                    Phosphorus = table.Column<decimal>(type: "TEXT", nullable: false),
                    Potassium = table.Column<decimal>(type: "TEXT", nullable: false),
                    Selenium = table.Column<decimal>(type: "TEXT", nullable: false),
                    Zinc = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FoodCategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodCategory_FoodCategoryId",
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
                        name: "FK_ComplexFoodComponent_Foods_ComplexFoodId",
                        column: x => x.ComplexFoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplexFoodComponent_Foods_SimpleFoodId",
                        column: x => x.SimpleFoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodRecord_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
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
                name: "IX_FoodRecord_FoodId",
                table: "FoodRecord",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplexFoodComponent");

            migrationBuilder.DropTable(
                name: "FoodRecord");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "FoodCategory");
        }
    }
}
