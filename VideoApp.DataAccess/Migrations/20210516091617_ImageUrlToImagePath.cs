using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoApp.DataAccess.Migrations
{
    public partial class ImageUrlToImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Channels",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Channels",
                newName: "ImageUrl");
        }
    }
}
