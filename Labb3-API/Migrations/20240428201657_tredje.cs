using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class tredje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Konsten att fånga ögonblick.", "Fotografering" },
                    { 2, "Utmaningen att nå toppen.", "Bergsklättring" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna Svensson", "0701234567" },
                    { 2, "Johan Karlsson", "0722345678" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonInterestId", "InterestId", "Links", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, "[]", 1 },
                    { 2, 2, "[]", 1 },
                    { 3, 1, "[]", 2 }
                });

            migrationBuilder.InsertData(
                table: "Link",
                columns: new[] { "LinkId", "PersonInterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "http://example.com/foto" },
                    { 2, 2, "http://example.com/bergsbestigning" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "LinkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Link",
                keyColumn: "LinkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumn: "PersonInterestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumn: "PersonInterestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumn: "PersonInterestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);
        }
    }
}
