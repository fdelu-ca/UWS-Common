using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class ChangeLogStruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UwsLogs_UwsLogDetails_UwsLogDetailId",
                table: "UwsLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UwsLogs_UwsLogTypes_UwsLogTypeId",
                table: "UwsLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UwsLogs_WeightingCollections_WeightingCollectionId",
                table: "UwsLogs");

            migrationBuilder.DropTable(
                name: "UwsLogDetails");

            migrationBuilder.DropTable(
                name: "UwsLogTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UwsLogs",
                table: "UwsLogs");

            migrationBuilder.DropIndex(
                name: "IX_UwsLogs_UwsLogDetailId",
                table: "UwsLogs");

            migrationBuilder.DropIndex(
                name: "IX_UwsLogs_UwsLogTypeId",
                table: "UwsLogs");

            migrationBuilder.DropIndex(
                name: "IX_UwsLogs_WeightingCollectionId",
                table: "UwsLogs");

            migrationBuilder.DropColumn(
                name: "RecognCollectionId",
                table: "UwsLogs");

            migrationBuilder.DropColumn(
                name: "ScalesSerial",
                table: "UwsLogs");

            migrationBuilder.DropColumn(
                name: "UwsLogDetailId",
                table: "UwsLogs");

            migrationBuilder.DropColumn(
                name: "UwsLogTypeId",
                table: "UwsLogs");

            migrationBuilder.DropColumn(
                name: "WeightingCollectionId",
                table: "UwsLogs");

            migrationBuilder.RenameTable(
                name: "UwsLogs",
                newName: "UwsLog");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "UwsLog",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Callsite",
                table: "UwsLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "UwsLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logger",
                table: "UwsLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "UwsLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessCellId",
                table: "UwsLog",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UwsLog",
                table: "UwsLog",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UwsLog",
                table: "UwsLog");

            migrationBuilder.DropColumn(
                name: "Callsite",
                table: "UwsLog");

            migrationBuilder.DropColumn(
                name: "Exception",
                table: "UwsLog");

            migrationBuilder.DropColumn(
                name: "Logger",
                table: "UwsLog");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "UwsLog");

            migrationBuilder.DropColumn(
                name: "ProcessCellId",
                table: "UwsLog");

            migrationBuilder.RenameTable(
                name: "UwsLog",
                newName: "UwsLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "UwsLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecognCollectionId",
                table: "UwsLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScalesSerial",
                table: "UwsLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UwsLogDetailId",
                table: "UwsLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UwsLogTypeId",
                table: "UwsLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightingCollectionId",
                table: "UwsLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UwsLogs",
                table: "UwsLogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UwsLogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UwsLogDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UwsLogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UwsLogTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogs_UwsLogDetailId",
                table: "UwsLogs",
                column: "UwsLogDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogs_UwsLogTypeId",
                table: "UwsLogs",
                column: "UwsLogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogs_WeightingCollectionId",
                table: "UwsLogs",
                column: "WeightingCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogTypes_Key",
                table: "UwsLogTypes",
                column: "Key",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UwsLogs_UwsLogDetails_UwsLogDetailId",
                table: "UwsLogs",
                column: "UwsLogDetailId",
                principalTable: "UwsLogDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UwsLogs_UwsLogTypes_UwsLogTypeId",
                table: "UwsLogs",
                column: "UwsLogTypeId",
                principalTable: "UwsLogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UwsLogs_WeightingCollections_WeightingCollectionId",
                table: "UwsLogs",
                column: "WeightingCollectionId",
                principalTable: "WeightingCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
