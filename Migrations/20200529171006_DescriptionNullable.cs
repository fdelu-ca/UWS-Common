using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class DescriptionNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StatusTypes",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldNullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StatusTypes",
                type: "datetime",
                nullable: false,
                oldNullable: true);
        }
    }
}
