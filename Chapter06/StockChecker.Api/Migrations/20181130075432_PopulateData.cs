using Microsoft.EntityFrameworkCore.Migrations;

namespace StockChecker.Api.Migrations
{
    public partial class PopulateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "StockCount" },
                values: new object[,]
                {
                    { 1, "1\" Nails", 0 },
                    { 2, "2\" Nails", 0 },
                    { 3, "1/4\" Screws", 0 },
                    { 4, "1/2\" Screws", 0 },
                    { 5, "3' x 3' Plasterboard", 0 },
                    { 6, "3' x 6' Plasterboard", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
