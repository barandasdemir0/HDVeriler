using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Veriler.Migrations
{
    /// <inheritdoc />
    public partial class _29032024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kat",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "projectCategories",
                columns: table => new
                {
                    ProjeCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeCategoryName = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectCategories", x => x.ProjeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeCategoryID = table.Column<int>(type: "int", nullable: false),
                    ProjeAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeKod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeKod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeResponsible = table.Column<int>(type: "int", nullable: false),
                    ProjeEngineer = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjeDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstalledCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IrrigationArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrainageArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "projectCategories");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Kat",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Users");
        }
    }
}
