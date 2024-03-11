using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD_Veriler.Migrations
{
    /// <inheritdoc />
    public partial class _28022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasifDate",
                table: "MonitorDetails");

            migrationBuilder.RenameColumn(
                name: "Material",
                table: "OtherInventorys",
                newName: "Feature");

            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "Entrusteds",
                newName: "OtherInventoryId");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "OtherInventorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Entrusteds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "OtherInventorys");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Entrusteds");

            migrationBuilder.RenameColumn(
                name: "Feature",
                table: "OtherInventorys",
                newName: "Material");

            migrationBuilder.RenameColumn(
                name: "OtherInventoryId",
                table: "Entrusteds",
                newName: "EquipmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "PasifDate",
                table: "MonitorDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
