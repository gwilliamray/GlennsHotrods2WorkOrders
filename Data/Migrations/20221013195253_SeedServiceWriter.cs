using Microsoft.EntityFrameworkCore.Migrations;

namespace GlennsHotrods2.Data.Migrations
{
    public partial class SeedServiceWriter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceWriters",
                columns: new[] { "ServiceWriterId", "Name" },
                values: new object[] { 1, "Glenn" });

            migrationBuilder.InsertData(
                table: "ServiceWriters",
                columns: new[] { "ServiceWriterId", "Name" },
                values: new object[] { 2, "Jennifer" });

            migrationBuilder.InsertData(
                table: "ServiceWriters",
                columns: new[] { "ServiceWriterId", "Name" },
                values: new object[] { 3, "Barney" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceWriters",
                keyColumn: "ServiceWriterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceWriters",
                keyColumn: "ServiceWriterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceWriters",
                keyColumn: "ServiceWriterId",
                keyValue: 3);
        }
    }
}
