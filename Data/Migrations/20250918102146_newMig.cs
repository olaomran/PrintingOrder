using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductionDetails_PrintSignatures_PrintSignatureId",
                table: "EmployeeProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineProductions_Machines_MachineId",
                table: "MachineProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineProductions_PrintSignatures_PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropIndex(
                name: "IX_MachineProductions_PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.AddColumn<int>(
                name: "DeliveriedCopiesToStore",
                table: "PrintOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MachineProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FoldedCopies",
                table: "MachineProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PrintedQuantity",
                table: "EmployeeProductionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PrintSignatureId",
                table: "EmployeeProductionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookSignatureId",
                table: "EmployeeProductionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DeliveryToStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryNumber = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isModified = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryToStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintOrderDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintOrderId = table.Column<int>(type: "int", nullable: true),
                    DeliveryId = table.Column<int>(type: "int", nullable: true),
                    DeliveyToStoreId = table.Column<int>(type: "int", nullable: true),
                    DeliverdAmount = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isModified = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintOrderDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintOrderDelivery_DeliveryToStore_DeliveyToStoreId",
                        column: x => x.DeliveyToStoreId,
                        principalTable: "DeliveryToStore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrintOrderDelivery_PrintOrders_PrintOrderId",
                        column: x => x.PrintOrderId,
                        principalTable: "PrintOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrderDelivery_DeliveyToStoreId",
                table: "PrintOrderDelivery",
                column: "DeliveyToStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrderDelivery_PrintOrderId",
                table: "PrintOrderDelivery",
                column: "PrintOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductionDetails_PrintSignatures_PrintSignatureId",
                table: "EmployeeProductionDetails",
                column: "PrintSignatureId",
                principalTable: "PrintSignatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineProductions_Machines_MachineId",
                table: "MachineProductions",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductionDetails_PrintSignatures_PrintSignatureId",
                table: "EmployeeProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineProductions_Machines_MachineId",
                table: "MachineProductions");

            migrationBuilder.DropTable(
                name: "PrintOrderDelivery");

            migrationBuilder.DropTable(
                name: "DeliveryToStore");

            migrationBuilder.DropColumn(
                name: "DeliveriedCopiesToStore",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "FoldedCopies",
                table: "MachineProductions");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "MachineProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintSignatureId",
                table: "MachineProductions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrintedQuantity",
                table: "EmployeeProductionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrintSignatureId",
                table: "EmployeeProductionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookSignatureId",
                table: "EmployeeProductionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineProductions_PrintSignatureId",
                table: "MachineProductions",
                column: "PrintSignatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductionDetails_PrintSignatures_PrintSignatureId",
                table: "EmployeeProductionDetails",
                column: "PrintSignatureId",
                principalTable: "PrintSignatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineProductions_Machines_MachineId",
                table: "MachineProductions",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineProductions_PrintSignatures_PrintSignatureId",
                table: "MachineProductions",
                column: "PrintSignatureId",
                principalTable: "PrintSignatures",
                principalColumn: "Id");
        }
    }
}
