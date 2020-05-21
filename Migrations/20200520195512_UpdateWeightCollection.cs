using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class UpdateWeightCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecNumber",
                table: "WeightElements",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightingOperationsID",
                table: "WeightElements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecNumber",
                table: "WeightElements");

            migrationBuilder.DropColumn(
                name: "WeightingOperationsID",
                table: "WeightElements");
        }
    }
}
