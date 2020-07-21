using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class UpdateLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(


                name: "PK_UwsLog",
                table: "UwsLog");

            migrationBuilder.RenameTable(
                name: "UwsLog",
                newName: "ServiceLog");
            
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Timestamp",
                table: "ServiceLog",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceLog",
                table: "ServiceLog",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceLog",
                table: "ServiceLog");

            migrationBuilder.RenameTable(
                name: "ServiceLog",
                newName: "UwsLog");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "UwsLog",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UwsLog",
                table: "UwsLog",
                column: "Id");
        }
    }
}
