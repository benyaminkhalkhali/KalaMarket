using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaMarket.DataLayer.Migrations
{
    public partial class updatetblproductgallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "productGalleries",
                newName: "GalleryTitle");

            migrationBuilder.AddColumn<string>(
                name: "GalleryImage",
                table: "productGalleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "productGalleries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalleryImage",
                table: "productGalleries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "productGalleries");

            migrationBuilder.RenameColumn(
                name: "GalleryTitle",
                table: "productGalleries",
                newName: "ImageName");
        }
    }
}
