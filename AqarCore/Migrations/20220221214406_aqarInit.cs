using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class aqarInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    View = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    AppartmentNumber = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    Baths = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    LaundryRoom = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyExit = table.Column<bool>(type: "bit", nullable: false),
                    FirePlace = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealStates_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_RealStates_RealstateId",
                        column: x => x.RealstateId,
                        principalTable: "RealStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealStates_CategoryId",
                table: "RealStates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RealstateId",
                table: "Transactions",
                column: "RealstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "RealStates");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
