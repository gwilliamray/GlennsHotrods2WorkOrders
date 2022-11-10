using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlennsHotrods2.Data.Migrations
{
    public partial class AddWOImageClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Completed",
                table: "workOrders",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WorkOrderImages",
                columns: table => new
                {
                    WorkOrderImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    WorkOrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderImages", x => x.WorkOrderImageId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderViewModel",
                columns: table => new
                {
                    WorkorderViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedTo = table.Column<string>(nullable: true),
                    WorkDescription = table.Column<string>(maxLength: 250, nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderViewModel", x => x.WorkorderViewModelId);
                    table.ForeignKey(
                        name: "FK_WorkOrderViewModel_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderViewModel_CustomerId",
                table: "WorkOrderViewModel",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrderImages");

            migrationBuilder.DropTable(
                name: "WorkOrderViewModel");

            migrationBuilder.AlterColumn<bool>(
                name: "Completed",
                table: "workOrders",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
