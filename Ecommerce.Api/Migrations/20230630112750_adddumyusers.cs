using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class adddumyusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "IsAdmin", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("177992d2-2e3d-4019-ada2-08fa700b0f8b"), 22, "hood@gmail.com", false, "HoodAhmed", "mo12343" },
                    { new Guid("473ae3f5-d410-43ea-826f-4709f658320e"), 21, "moaml@gmail.com", true, "Moaml Rh", "mo12345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("177992d2-2e3d-4019-ada2-08fa700b0f8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("473ae3f5-d410-43ea-826f-4709f658320e"));
        }
    }
}
