using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingOrder.Migrations
{
    /// <inheritdoc />
    public partial class newMigDBValidators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Customers_CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_PrintSizes_PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.AlterColumn<int>(
                name: "PrintSizeId",
                table: "PrintOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "PrintOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Delegates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_Customers_CustomerId",
                table: "PrintOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_PrintSizes_PrintSizeId",
                table: "PrintOrders",
                column: "PrintSizeId",
                principalTable: "PrintSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Customers_CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_PrintSizes_PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.AlterColumn<int>(
                name: "PrintSizeId",
                table: "PrintOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "PrintOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Delegates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_Customers_CustomerId",
                table: "PrintOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_PrintSizes_PrintSizeId",
                table: "PrintOrders",
                column: "PrintSizeId",
                principalTable: "PrintSizes",
                principalColumn: "Id");
        }
    }
}
