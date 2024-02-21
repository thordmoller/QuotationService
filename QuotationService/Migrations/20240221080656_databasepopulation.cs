using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuotationService.Migrations
{
    public partial class databasepopulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "Rate" },
                values: new object[] { 1, "Stockholm", 65m });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "Rate" },
                values: new object[] { 2, "Uppsala", 55m });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Fönsterputs", 300m },
                    { 2, 1, "Balkongstädning", 150m },
                    { 3, 2, "Fönsterputs", 300m },
                    { 4, 2, "Balkongstädning", 150m },
                    { 5, 2, "Bortforsling av skräp", 400m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
