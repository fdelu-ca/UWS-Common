using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class AddWayBillId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WayBillId",
                table: "WeightingElements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WayBillId",
                table: "WeightingElements");
        }
    }
}
