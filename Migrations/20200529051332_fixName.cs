using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class fixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightingOperationsID",
                table: "WeightingElements",
                newName: "WeightingOperationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightingOperationsId",
                table: "WeightingElements",
                newName: "WeightingOperationsID");
        }
    }
}
