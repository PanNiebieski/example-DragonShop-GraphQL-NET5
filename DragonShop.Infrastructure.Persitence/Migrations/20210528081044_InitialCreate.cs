using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DragonShop.Infrastructure.Persitence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dragons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    IntroducedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    CrewCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DiameterMeters = table.Column<double>(type: "REAL", nullable: false),
                    DryMassKg = table.Column<int>(type: "INTEGER", nullable: false),
                    DoneFirstFlight = table.Column<bool>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    OrbitDurationYears = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<int>(type: "INTEGER", nullable: false),
                    Breath = table.Column<int>(type: "INTEGER", nullable: false),
                    HeightInMeters = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dragons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dragons");
        }
    }
}
