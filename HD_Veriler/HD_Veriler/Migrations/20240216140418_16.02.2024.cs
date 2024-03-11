using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Veriler.Migrations
{
    /// <inheritdoc />
    public partial class _16022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stillworking",
                table: "Users",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "Stillworking");
        }
    }
}
