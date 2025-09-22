using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingOrder.Migrations
{
    /// <inheritdoc />
    public partial class newmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MachineType",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SignaturePrintMechanismSignatureStatus",
                table: "EmployeeProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineType",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "SignaturePrintMechanismSignatureStatus",
                table: "EmployeeProductions");
        }
    }
}
