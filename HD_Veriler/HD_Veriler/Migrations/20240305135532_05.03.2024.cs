using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Veriler.Migrations
{
    /// <inheritdoc />
    public partial class _05032024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmanID",
                table: "Users",
                column: "DepartmanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departmans_DepartmanID",
                table: "Users",
                column: "DepartmanID",
                principalTable: "Departmans",
                principalColumn: "DepartmanID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departmans_DepartmanID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmanID",
                table: "Users");
        }
    }
}
