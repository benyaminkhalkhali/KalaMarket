using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class updatetblyekchizi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "cartDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "cartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
