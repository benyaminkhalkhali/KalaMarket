using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class updatetblcartdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "cartDetails",
                newName: "ProductCount");

            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "cartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "cartDetails");

            migrationBuilder.RenameColumn(
                name: "ProductCount",
                table: "cartDetails",
                newName: "Count");
        }
    }
}
