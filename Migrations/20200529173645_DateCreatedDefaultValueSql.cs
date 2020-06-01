using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class DateCreatedDefaultValueSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StatusTypes",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
