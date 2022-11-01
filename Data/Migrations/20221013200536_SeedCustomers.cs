using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlennsHotrods2.Data.Migrations
{
    public partial class SeedCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Contact", "CreateDate", "CustomerName", "Email", "Phone1", "Phone2", "ServiceWriterId" },
                values: new object[] { 1, "Val", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Val Kilmer", "vk@scc.com", "402-555-5555", null, 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Contact", "CreateDate", "CustomerName", "Email", "Phone1", "Phone2", "ServiceWriterId" },
                values: new object[] { 2, "Tom", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Cruse", "tc@scc.com", "402-555-6666", null, 3 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Contact", "CreateDate", "CustomerName", "Email", "Phone1", "Phone2", "ServiceWriterId" },
                values: new object[] { 3, "Jack", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack Benny", "jb@scc.com", "402-555-7777", null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);
        }
    }
}
