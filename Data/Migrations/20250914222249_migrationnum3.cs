using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationnum3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutorsJson",
                table: "MachineProductions");

            migrationBuilder.RenameColumn(
                name: "DurationHours",
                table: "MachineProductions",
                newName: "Hours");

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                table: "MachineProductions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "MachineProductions",
                newName: "DurationHours");

            migrationBuilder.AlterColumn<int>(
                name: "Section",
                table: "MachineProductions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ExecutorsJson",
                table: "MachineProductions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
