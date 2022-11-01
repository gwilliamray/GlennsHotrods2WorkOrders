using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlennsHotrods2.Data.Migrations
{
    public partial class AddWorkOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workOrders",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedTo = table.Column<string>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 250, nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workOrders", x => x.WorkOrderId);
                    table.ForeignKey(
                        name: "FK_workOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workOrders_CustomerId",
                table: "workOrders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workOrders");
        }
    }
}
