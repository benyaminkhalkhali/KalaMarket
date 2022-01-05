using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class updatetblproductgallery3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "productGalleries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "productGalleries");
        }
    }
}
