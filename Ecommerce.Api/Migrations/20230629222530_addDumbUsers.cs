using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class addDumbUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "IsAdmin", "Name", "Password" },
                values: new object[,]
                {
                    { 1, 20, "ahmed@gmail.com", false, "ahmed ali", "123456" },
                    { 2, 22, "moaml@gmail.com", true, "moaml rh", "asdfjl832" },
                    { 3, 30, "ali@gmail.com", false, "ali yousef", "123456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
