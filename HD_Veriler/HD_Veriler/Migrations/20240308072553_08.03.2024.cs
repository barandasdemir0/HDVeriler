using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Veriler.Migrations
{
    /// <inheritdoc />
    public partial class _08032024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
