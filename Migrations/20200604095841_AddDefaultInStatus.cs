using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class AddDefaultInStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Default",
                table: "StatusTypes",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Statuses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Default",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Statuses");
        }
    }
}
