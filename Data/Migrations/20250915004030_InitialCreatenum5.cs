using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatenum5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoldedCopies",
                table: "PrintOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Section",
                table: "MachineProductions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoldedCopies",
                table: "PrintOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                table: "MachineProductions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
