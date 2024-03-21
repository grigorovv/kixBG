using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kixBG.Data.Migrations
{
    public partial class ForgotImageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "URL of item image");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "URL of item image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Clothes");
        }
    }
}
