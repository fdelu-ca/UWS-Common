using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class CorrectWeighting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightingCollectionProperties_WeightPropertyTypes_WeightPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropTable(
                name: "WeightElementProperties");

            migrationBuilder.DropTable(
                name: "WeightElements");

            migrationBuilder.DropTable(
                name: "WeightPropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_WeightingCollectionProperties_WeightPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "UwsLogs");

            migrationBuilder.AddColumn<int>(
                name: "WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScalesSerial",
                table: "UwsLogs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeightingElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    WeightingCollectionId = table.Column<int>(nullable: true),
                    VehicleId = table.Column<int>(nullable: true),
                    VehicleType = table.Column<int>(nullable: false),
                    AxisCount = table.Column<int>(nullable: true),
                    Length = table.Column<int>(nullable: true),
                    WeightingOperationsID = table.Column<int>(nullable: true),
                    RecNumber = table.Column<string>(maxLength: 10, nullable: true),
                    TypeWeight = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: true),
                    Quality = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightingElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentId_Shipments",
                        column: x => x.WeightingCollectionId,
                        principalTable: "WeightingCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightingPropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightingPropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightingElementProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightElementId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Value = table.Column<string>(maxLength: 30, nullable: true),
                    WeightPropertyTypeId = table.Column<int>(nullable: false),
                    WeightingPropertyTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightingElementProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightingElementProperties_WeightingElements_WeightElementId",
                        column: x => x.WeightElementId,
                        principalTable: "WeightingElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeightingElementProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                        column: x => x.WeightingPropertyTypeId,
                        principalTable: "WeightingPropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightingCollectionProperties_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                column: "WeightingPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightingElementProperties_WeightElementId",
                table: "WeightingElementProperties",
                column: "WeightElementId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightingElementProperties_WeightingPropertyTypeId",
                table: "WeightingElementProperties",
                column: "WeightingPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightingElements_WeightingCollectionId",
                table: "WeightingElements",
                column: "WeightingCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightingPropertyTypes_Key",
                table: "WeightingPropertyTypes",
                column: "Key",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightingCollectionProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties",
                column: "WeightingPropertyTypeId",
                principalTable: "WeightingPropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightingCollectionProperties_WeightingPropertyTypes_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropTable(
                name: "WeightingElementProperties");

            migrationBuilder.DropTable(
                name: "WeightingElements");

            migrationBuilder.DropTable(
                name: "WeightingPropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_WeightingCollectionProperties_WeightingPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropColumn(
                name: "WeightingPropertyTypeId",
                table: "WeightingCollectionProperties");

            migrationBuilder.DropColumn(
                name: "ScalesSerial",
                table: "UwsLogs");

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "UwsLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeightElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AxisCount = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    RecNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TypeWeight = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    WeightingCollectionId = table.Column<int>(type: "int", nullable: true),
                    WeightingOperationsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentId_Shipments",
                        column: x => x.WeightingCollectionId,
                        principalTable: "WeightingCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightPropertyTypes",
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
                    table.PrimaryKey("PK_WeightPropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightElementProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    WeightElementId = table.Column<int>(type: "int", nullable: false),
                    WeightPropertyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightElementProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightElementProperties_WeightElements_WeightElementId",
                        column: x => x.WeightElementId,
                        principalTable: "WeightElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeightElementProperties_WeightPropertyTypes_WeightPropertyTypeId",
                        column: x => x.WeightPropertyTypeId,
                        principalTable: "WeightPropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightingCollectionProperties_WeightPropertyTypeId",
                table: "WeightingCollectionProperties",
                column: "WeightPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightElementProperties_WeightElementId",
                table: "WeightElementProperties",
                column: "WeightElementId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightElementProperties_WeightPropertyTypeId",
                table: "WeightElementProperties",
                column: "WeightPropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightElements_WeightingCollectionId",
                table: "WeightElements",
                column: "WeightingCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightPropertyTypes_Key",
                table: "WeightPropertyTypes",
                column: "Key",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightingCollectionProperties_WeightPropertyTypes_WeightPropertyTypeId",
                table: "WeightingCollectionProperties",
                column: "WeightPropertyTypeId",
                principalTable: "WeightPropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
