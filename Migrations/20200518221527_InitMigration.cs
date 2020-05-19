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
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UwsLogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<byte>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    FactoryTara = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "WeightCollections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalId = table.Column<long>(nullable: false),
                    Begin = table.Column<DateTimeOffset>(nullable: true),
                    End = table.Column<DateTimeOffset>(nullable: true),
                    StationId = table.Column<int>(nullable: true),
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
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightPropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    Value = table.Column<string>(maxLength: 30, nullable: true),
                    VehiclePropertyTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleProperties_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleProperties_VehiclePropertyTypes_VehiclePropertyTypeId",
                        column: x => x.VehiclePropertyTypeId,
                        principalTable: "VehiclePropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StageHistories",
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
                    table.PrimaryKey("PK_StageHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageHistories_StageHistories_LastStageId",
                        column: x => x.LastStageId,
                        principalTable: "StageHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StageHistories_WeightCollections_WeightCollectionId",
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
                    AxisCount = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    TypeWeight = table.Column<byte>(nullable: false),
                    Weight = table.Column<double>(nullable: true),
                    Speed = table.Column<float>(nullable: true),
                    Quality = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightElements_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_StageHistories_LastStageId",
                table: "StageHistories",
                column: "LastStageId",
                unique: true,
                filter: "[LastStageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StageHistories_WeightCollectionId",
                table: "StageHistories",
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
                name: "IX_VehicleProperties_VehicleId",
                table: "VehicleProperties",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProperties_VehiclePropertyTypeId",
                table: "VehicleProperties",
                column: "VehiclePropertyTypeId");

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
                name: "IX_WeightElements_VehicleId",
                table: "WeightElements",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightElements_WeightCollectionId",
                table: "WeightElements",
                column: "WeightCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageHistories");

            migrationBuilder.DropTable(
                name: "UwsLogs");

            migrationBuilder.DropTable(
                name: "VehicleProperties");

            migrationBuilder.DropTable(
                name: "WeightCollectionProperties");

            migrationBuilder.DropTable(
                name: "WeightElementProperties");

            migrationBuilder.DropTable(
                name: "UwsLogDetails");

            migrationBuilder.DropTable(
                name: "UwsLogTypes");

            migrationBuilder.DropTable(
                name: "VehiclePropertyTypes");

            migrationBuilder.DropTable(
                name: "WeightElements");

            migrationBuilder.DropTable(
                name: "WeightPropertyTypes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "WeightCollections");
        }
    }
}
