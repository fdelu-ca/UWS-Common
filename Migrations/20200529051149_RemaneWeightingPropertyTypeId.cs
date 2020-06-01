using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class RemaneWeightingPropertyTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightingCollectionProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightingElementProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingElementProperties");

            migrationBuilder.DropColumn(
                name: "WeightPropertyTypeId",
                table: "WeightingElementProperties");

            migrationBuilder.DropColumn(
                name: "WeightPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.AlterColumn<int>(
                name: "WeightingPropertyTypeId",
                table: "WeightingElementProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightingCollectionProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                column: "WeightingPropertyTypeId",
                principalTable: "WeightingPropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightingElementProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingElementProperties",
                column: "WeightingPropertyTypeId",
                principalTable: "WeightingPropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightingCollectionProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_WeightingElementProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingElementProperties");

            migrationBuilder.AlterColumn<int>(
                name: "WeightingPropertyTypeId",
                table: "WeightingElementProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "WeightPropertyTypeId",
                table: "WeightingElementProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "WeightPropertyTypeId",
                table: "WeightingCollectionProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightingCollectionProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                column: "WeightingPropertyTypeId",
                principalTable: "WeightingPropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightingElementProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingElementProperties",
                column: "WeightingPropertyTypeId",
                principalTable: "WeightingPropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
