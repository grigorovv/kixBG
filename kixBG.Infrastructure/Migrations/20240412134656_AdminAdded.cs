using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kixBG.Data.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                comment: "Seller full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Seller full name");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Clothes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Model(name) of clothing",
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldComment: "Model(name) of clothing");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "8b58c976-3dac-4860-a774-d1926cfc9a28", "kixbgadmin@gmail.com", false, false, null, "KIXBGADMIN@GMAIL.COM", "KIXBGADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEK+ia2EjzMvl46C6ptuf119iVP5j/pAL5jxqqZbtBGhP9AFEXQ4IjtFTXqZb8livUA==", null, false, "f7acfb0b-f0f5-4e81-8e1e-2f43434ee7a9", false, "kixbgadmin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Seller full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldComment: "Seller full name");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Clothes",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                comment: "Model(name) of clothing",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Model(name) of clothing");
        }
    }
}
