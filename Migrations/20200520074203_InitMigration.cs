using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArcelorMittal.UnifiedWeightSystem.Common.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UwsLogDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UwsLogDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UwsLogTypes",
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
                    table.PrimaryKey("PK_UwsLogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightCollections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalId = table.Column<long>(nullable: false),
                    DtBegin = table.Column<DateTimeOffset>(nullable: true),
                    DtEnd = table.Column<DateTimeOffset>(nullable: true),
                    ScalesSerial = table.Column<int>(nullable: true),
                    Direction = table.Column<byte>(nullable: false),
                    Stage = table.Column<byte>(nullable: false),
                    Release = table.Column<bool>(nullable: false),
                    TrainStatus = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightPropertyTypes",
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
                    table.PrimaryKey("PK_WeightPropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastStageId = table.Column<long>(nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Stage = table.Column<byte>(nullable: false),
                    WeightCollectionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageHistory_StageHistory_LastStageId",
                        column: x => x.LastStageId,
                        principalTable: "StageHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StageHistory_WeightCollections_WeightCollectionId",
                        column: x => x.WeightCollectionId,
                        principalTable: "WeightCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UwsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    WeightCollectionId = table.Column<long>(nullable: true),
                    RecognCollectionId = table.Column<int>(nullable: true),
                    StationId = table.Column<int>(nullable: true),
                    UwsLogTypeId = table.Column<int>(nullable: true),
                    UwsLogDetailId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UwsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UwsLogs_UwsLogDetails_UwsLogDetailId",
                        column: x => x.UwsLogDetailId,
                        principalTable: "UwsLogDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UwsLogs_UwsLogTypes_UwsLogTypeId",
                        column: x => x.UwsLogTypeId,
                        principalTable: "UwsLogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UwsLogs_WeightCollections_WeightCollectionId",
                        column: x => x.WeightCollectionId,
                        principalTable: "WeightCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightElements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<byte>(nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    WeightCollectionId = table.Column<long>(nullable: true),
                    VehicleId = table.Column<int>(nullable: true),
                    VehicleType = table.Column<byte>(nullable: false),
                    AxisCount = table.Column<int>(nullable: true),
                    Length = table.Column<int>(nullable: true),
                    TypeWeight = table.Column<byte>(nullable: false),
                    Weight = table.Column<double>(nullable: true),
                    Speed = table.Column<double>(nullable: true),
                    Quality = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentId_Shipments",
                        column: x => x.WeightCollectionId,
                        principalTable: "WeightCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightCollectionProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightCollectionId = table.Column<long>(nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Value = table.Column<string>(maxLength: 30, nullable: true),
                    WeightPropertyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightCollectionProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightCollectionProperties_WeightCollections_WeightCollectionId",
                        column: x => x.WeightCollectionId,
                        principalTable: "WeightCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeightCollectionProperties_WeightPropertyTypes_WeightPropertyTypeId",
                        column: x => x.WeightPropertyTypeId,
                        principalTable: "WeightPropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightElementProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightElementId = table.Column<long>(nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Value = table.Column<string>(maxLength: 30, nullable: true),
                    WeightPropertyTypeId = table.Column<int>(nullable: false)
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
                name: "IX_StageHistory_LastStageId",
                table: "StageHistory",
                column: "LastStageId",
                unique: true,
                filter: "[LastStageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StageHistory_WeightCollectionId",
                table: "StageHistory",
                column: "WeightCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogs_UwsLogDetailId",
                table: "UwsLogs",
                column: "UwsLogDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogs_UwsLogTypeId",
                table: "UwsLogs",
                column: "UwsLogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogs_WeightCollectionId",
                table: "UwsLogs",
                column: "WeightCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UwsLogTypes_Key",
                table: "UwsLogTypes",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeightCollectionProperties_WeightCollectionId",
                table: "WeightCollectionProperties",
                column: "WeightCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightCollectionProperties_WeightPropertyTypeId",
                table: "WeightCollectionProperties",
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
                name: "IX_WeightElements_WeightCollectionId",
                table: "WeightElements",
                column: "WeightCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightPropertyTypes_Key",
                table: "WeightPropertyTypes",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageHistory");

            migrationBuilder.DropTable(
                name: "UwsLogs");

            migrationBuilder.DropTable(
                name: "WeightCollectionProperties");

            migrationBuilder.DropTable(
                name: "WeightElementProperties");

            migrationBuilder.DropTable(
                name: "UwsLogDetails");

            migrationBuilder.DropTable(
                name: "UwsLogTypes");

            migrationBuilder.DropTable(
                name: "WeightElements");

            migrationBuilder.DropTable(
                name: "WeightPropertyTypes");

            migrationBuilder.DropTable(
                name: "WeightCollections");
        }
    }
}
