using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class updatetblcartdetail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "cartDetails",
                newName: "Product_PriceID");

            migrationBuilder.AlterColumn<string>(
                name: "GalleryImage",
                table: "productGalleries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Product_ID",
                table: "cartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_ID",
                table: "cartDetails");

            migrationBuilder.RenameColumn(
                name: "Product_PriceID",
                table: "cartDetails",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "GalleryImage",
                table: "productGalleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
