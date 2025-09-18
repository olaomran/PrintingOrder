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
                name: "FK_EmployeeProductions_Employees_EmployeeId",
                table: "EmployeeProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductions_MachineProductions_MachineProductionId",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "ProducedCopies",
                table: "MachineProductions");

            migrationBuilder.RenameColumn(
                name: "TotalBooklets",
                table: "PrintOrders",
                newName: "PrintOrderType");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "PrintOrders",
                newName: "OrderYear");

            migrationBuilder.RenameColumn(
                name: "MachineType",
                table: "PrintOrders",
                newName: "PrintOrderLevel");

            migrationBuilder.RenameColumn(
                name: "ShiftsJson",
                table: "EmployeeProductions",
                newName: "Shifts");

            migrationBuilder.RenameColumn(
                name: "BookletNumbersJson",
                table: "EmployeeProductions",
                newName: "ModifyUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AgreedDeliveryDate",
                table: "PrintOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PrintOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DelegateId",
                table: "PrintOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PrintOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "PrintOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IntryDate",
                table: "PrintOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntryNumber",
                table: "PrintOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PrintOrders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "PrintOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "PrintOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PartyBookDate",
                table: "PrintOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartyBookNumber",
                table: "PrintOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrintSignatureCount",
                table: "PrintOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PrintSizeId",
                table: "PrintOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrintSignatureCount",
                table: "PrintOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isClaimed",
                table: "PrintOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                table: "PrintOrders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPaied",
                table: "PrintOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Machines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Machines",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Machines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                table: "Machines",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MachineProductions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "MachineProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MachineProductions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "MachineProductions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "MachineProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintSignatureId",
                table: "MachineProductions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                table: "MachineProductions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                table: "Employees",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MachineProductionId",
                table: "EmployeeProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeProductions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "EmployeeProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "EmployeeProductions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "EmployeeProductions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeProductions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "EmployeeProductions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                table: "EmployeeProductions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DailyReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedUserId",
                table: "DailyReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DailyReports",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "DailyReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "DailyReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isModified",
                table: "DailyReports",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Delegate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Delegate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintSignature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintOrderId = table.Column<int>(type: "int", nullable: false),
                    SignatureOrder = table.Column<int>(type: "int", nullable: false),
                    WholeSignature = table.Column<bool>(type: "bit", nullable: true),
                    SignaturePart = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PagesCount = table.Column<int>(type: "int", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "int", nullable: false),
                    CompletedQuantity = table.Column<int>(type: "int", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "int", nullable: false),
                    SignatureStatus = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PrintSignature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintSignature_PrintOrders_PrintOrderId",
                        column: x => x.PrintOrderId,
                        principalTable: "PrintOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PrintSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProductionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeProductionId = table.Column<int>(type: "int", nullable: false),
                    BookSignatureId = table.Column<int>(type: "int", nullable: false),
                    PrintSignatureId = table.Column<int>(type: "int", nullable: false),
                    PrintedQuantity = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeProductionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProductionDetail_EmployeeProductions_EmployeeProductionId",
                        column: x => x.EmployeeProductionId,
                        principalTable: "EmployeeProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProductionDetail_PrintSignature_PrintSignatureId",
                        column: x => x.PrintSignatureId,
                        principalTable: "PrintSignature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    ItemsInUnit = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unit_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    SubOrder = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrintOrderRequiredItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintOrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    RequiredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_PrintOrderRequiredItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintOrderRequiredItems_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrintOrderRequiredItems_PrintOrders_PrintOrderId",
                        column: x => x.PrintOrderId,
                        principalTable: "PrintOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrders_CustomerId",
                table: "PrintOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrders_DelegateId",
                table: "PrintOrders",
                column: "DelegateId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrders_PrintSizeId",
                table: "PrintOrders",
                column: "PrintSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineProductions_PrintSignatureId",
                table: "MachineProductions",
                column: "PrintSignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_StoreId",
                table: "Category",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductionDetail_EmployeeProductionId",
                table: "EmployeeProductionDetail",
                column: "EmployeeProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductionDetail_PrintSignatureId",
                table: "EmployeeProductionDetail",
                column: "PrintSignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UnitId",
                table: "Item",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrderRequiredItems_ItemId",
                table: "PrintOrderRequiredItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrderRequiredItems_PrintOrderId",
                table: "PrintOrderRequiredItems",
                column: "PrintOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintSignature_PrintOrderId",
                table: "PrintSignature",
                column: "PrintOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_StoreId",
                table: "Unit",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UnitId",
                table: "Unit",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductions_Employees_EmployeeId",
                table: "EmployeeProductions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductions_MachineProductions_MachineProductionId",
                table: "EmployeeProductions",
                column: "MachineProductionId",
                principalTable: "MachineProductions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineProductions_PrintSignature_PrintSignatureId",
                table: "MachineProductions",
                column: "PrintSignatureId",
                principalTable: "PrintSignature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_Customer_CustomerId",
                table: "PrintOrders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_Delegate_DelegateId",
                table: "PrintOrders",
                column: "DelegateId",
                principalTable: "Delegate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_PrintSize_PrintSizeId",
                table: "PrintOrders",
                column: "PrintSizeId",
                principalTable: "PrintSize",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductions_Employees_EmployeeId",
                table: "EmployeeProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductions_MachineProductions_MachineProductionId",
                table: "EmployeeProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineProductions_PrintSignature_PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Customer_CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Delegate_DelegateId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_PrintSize_PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Delegate");

            migrationBuilder.DropTable(
                name: "EmployeeProductionDetail");

            migrationBuilder.DropTable(
                name: "PrintOrderRequiredItems");

            migrationBuilder.DropTable(
                name: "PrintSize");

            migrationBuilder.DropTable(
                name: "PrintSignature");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_PrintOrders_CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropIndex(
                name: "IX_PrintOrders_DelegateId",
                table: "PrintOrders");

            migrationBuilder.DropIndex(
                name: "IX_PrintOrders_PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.DropIndex(
                name: "IX_MachineProductions_PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "AgreedDeliveryDate",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "DelegateId",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "IntryDate",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "IntryNumber",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "PartyBookDate",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "PartyBookNumber",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "PrintSignatureCount",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrintSignatureCount",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "isClaimed",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "isModified",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "isPaied",
                table: "PrintOrders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "isModified",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "isModified",
                table: "MachineProductions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isModified",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "isModified",
                table: "EmployeeProductions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "isModified",
                table: "DailyReports");

            migrationBuilder.RenameColumn(
                name: "PrintOrderType",
                table: "PrintOrders",
                newName: "TotalBooklets");

            migrationBuilder.RenameColumn(
                name: "PrintOrderLevel",
                table: "PrintOrders",
                newName: "MachineType");

            migrationBuilder.RenameColumn(
                name: "OrderYear",
                table: "PrintOrders",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "Shifts",
                table: "EmployeeProductions",
                newName: "ShiftsJson");

            migrationBuilder.RenameColumn(
                name: "ModifyUserId",
                table: "EmployeeProductions",
                newName: "BookletNumbersJson");

            migrationBuilder.AddColumn<int>(
                name: "ProducedCopies",
                table: "MachineProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MachineProductionId",
                table: "EmployeeProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductions_Employees_EmployeeId",
                table: "EmployeeProductions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductions_MachineProductions_MachineProductionId",
                table: "EmployeeProductions",
                column: "MachineProductionId",
                principalTable: "MachineProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
