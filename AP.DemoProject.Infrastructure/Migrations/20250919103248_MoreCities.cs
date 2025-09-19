using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AP.DemoProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Population" },
                values: new object[,]
                {
                    { -30, -3, "Arnhem", 250000 },
                    { -29, -3, "Zwolle", 180000 },
                    { -28, -3, "Delft", 150000 },
                    { -27, -3, "Leiden", 250000 },
                    { -26, -3, "Tilburg", 350000 },
                    { -25, -3, "Maastricht", 300000 },
                    { -24, -3, "Groningen", 400000 },
                    { -23, -3, "Eindhoven", 900000 },
                    { -22, -3, "Utrecht", 1200000 },
                    { -21, -3, "The Hague", 1800000 },
                    { -20, -3, "Rotterdam", 2000000 },
                    { -19, -2, "Montpellier", 700000 },
                    { -18, -2, "Strasbourg", 750000 },
                    { -17, -2, "Bordeaux", 850000 },
                    { -16, -2, "Nantes", 600000 },
                    { -15, -2, "Nice", 900000 },
                    { -14, -2, "Toulouse", 1200000 },
                    { -13, -2, "Lyon", 2000000 },
                    { -12, -2, "Marseille", 3000000 },
                    { -11, -1, "Liège", 500000 },
                    { -10, -1, "Namur", 150000 },
                    { -9, -1, "Leuven", 200000 },
                    { -8, -1, "Brugge", 300000 },
                    { -7, -1, "Gent", 800000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -30);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: -7);
        }
    }
}
