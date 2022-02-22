using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class aqarStep1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "Title",
               table: "RealStates",
               type: "nvarchar(100)",
               maxLength: 100,
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(50)",
               oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "RealStates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Floor",
            table: "RealStates");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "RealStates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
