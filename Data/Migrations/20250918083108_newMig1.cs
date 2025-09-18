using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class newMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Store_StoreId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductionDetail_EmployeeProductions_EmployeeProductionId",
                table: "EmployeeProductionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductionDetail_PrintSignature_PrintSignatureId",
                table: "EmployeeProductionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Unit_UnitId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineProductions_PrintSignature_PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrderRequiredItems_Item_ItemId",
                table: "PrintOrderRequiredItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Customer_CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Delegate_DelegateId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_PrintSize_PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintSignature_PrintOrders_PrintOrderId",
                table: "PrintSignature");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Store_StoreId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Unit_UnitId",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrintSize",
                table: "PrintSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrintSignature",
                table: "PrintSignature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProductionDetail",
                table: "EmployeeProductionDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delegate",
                table: "Delegate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "PrintSize",
                newName: "PrintSizes");

            migrationBuilder.RenameTable(
                name: "PrintSignature",
                newName: "PrintSignatures");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "EmployeeProductionDetail",
                newName: "EmployeeProductionDetails");

            migrationBuilder.RenameTable(
                name: "Delegate",
                newName: "Delegates");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_UnitId",
                table: "Units",
                newName: "IX_Units_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_StoreId",
                table: "Units",
                newName: "IX_Units_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_PrintSignature_PrintOrderId",
                table: "PrintSignatures",
                newName: "IX_PrintSignatures_PrintOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UnitId",
                table: "Items",
                newName: "IX_Items_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CategoryId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProductionDetail_PrintSignatureId",
                table: "EmployeeProductionDetails",
                newName: "IX_EmployeeProductionDetails_PrintSignatureId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProductionDetail_EmployeeProductionId",
                table: "EmployeeProductionDetails",
                newName: "IX_EmployeeProductionDetails_EmployeeProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_StoreId",
                table: "Categories",
                newName: "IX_Categories_StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrintSizes",
                table: "PrintSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrintSignatures",
                table: "PrintSignatures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProductionDetails",
                table: "EmployeeProductionDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delegates",
                table: "Delegates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimNumber = table.Column<int>(type: "int", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimValue = table.Column<long>(type: "bigint", nullable: false),
                    ClaimNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentValue = table.Column<long>(type: "bigint", nullable: true),
                    PaymentsNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PaymentClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionConsumedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineProductionId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ConsumedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isDamaging = table.Column<bool>(type: "bit", nullable: false),
                    isSaving = table.Column<bool>(type: "bit", nullable: false),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProductionConsumedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionConsumedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionConsumedItems_MachineProductions_MachineProductionId",
                        column: x => x.MachineProductionId,
                        principalTable: "MachineProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintOrderCalimPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentClaimId = table.Column<int>(type: "int", nullable: true),
                    PrintOrderId = table.Column<int>(type: "int", nullable: true),
                    PartNumber = table.Column<int>(type: "int", nullable: true),
                    ClaimedValue = table.Column<long>(type: "bigint", nullable: false),
                    ClaimNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentValue = table.Column<long>(type: "bigint", nullable: true),
                    PaymentsNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PrintOrderCalimPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintOrderCalimPayments_PaymentClaims_PaymentClaimId",
                        column: x => x.PaymentClaimId,
                        principalTable: "PaymentClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrintOrderCalimPayments_PrintOrders_PrintOrderId",
                        column: x => x.PrintOrderId,
                        principalTable: "PrintOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrderCalimPayments_PaymentClaimId",
                table: "PrintOrderCalimPayments",
                column: "PaymentClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrderCalimPayments_PrintOrderId",
                table: "PrintOrderCalimPayments",
                column: "PrintOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionConsumedItems_ItemId",
                table: "ProductionConsumedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionConsumedItems_MachineProductionId",
                table: "ProductionConsumedItems",
                column: "MachineProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductionDetails_EmployeeProductions_EmployeeProductionId",
                table: "EmployeeProductionDetails",
                column: "EmployeeProductionId",
                principalTable: "EmployeeProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductionDetails_PrintSignatures_PrintSignatureId",
                table: "EmployeeProductionDetails",
                column: "PrintSignatureId",
                principalTable: "PrintSignatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Units_UnitId",
                table: "Items",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineProductions_PrintSignatures_PrintSignatureId",
                table: "MachineProductions",
                column: "PrintSignatureId",
                principalTable: "PrintSignatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrderRequiredItems_Items_ItemId",
                table: "PrintOrderRequiredItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_Customers_CustomerId",
                table: "PrintOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_Delegates_DelegateId",
                table: "PrintOrders",
                column: "DelegateId",
                principalTable: "Delegates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrders_PrintSizes_PrintSizeId",
                table: "PrintOrders",
                column: "PrintSizeId",
                principalTable: "PrintSizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintSignatures_PrintOrders_PrintOrderId",
                table: "PrintSignatures",
                column: "PrintOrderId",
                principalTable: "PrintOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Stores_StoreId",
                table: "Units",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Units_UnitId",
                table: "Units",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductionDetails_EmployeeProductions_EmployeeProductionId",
                table: "EmployeeProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProductionDetails_PrintSignatures_PrintSignatureId",
                table: "EmployeeProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Units_UnitId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineProductions_PrintSignatures_PrintSignatureId",
                table: "MachineProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrderRequiredItems_Items_ItemId",
                table: "PrintOrderRequiredItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Customers_CustomerId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_Delegates_DelegateId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintOrders_PrintSizes_PrintSizeId",
                table: "PrintOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintSignatures_PrintOrders_PrintOrderId",
                table: "PrintSignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Stores_StoreId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Units_UnitId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "PrintOrderCalimPayments");

            migrationBuilder.DropTable(
                name: "ProductionConsumedItems");

            migrationBuilder.DropTable(
                name: "PaymentClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrintSizes",
                table: "PrintSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrintSignatures",
                table: "PrintSignatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProductionDetails",
                table: "EmployeeProductionDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delegates",
                table: "Delegates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.RenameTable(
                name: "PrintSizes",
                newName: "PrintSize");

            migrationBuilder.RenameTable(
                name: "PrintSignatures",
                newName: "PrintSignature");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "EmployeeProductionDetails",
                newName: "EmployeeProductionDetail");

            migrationBuilder.RenameTable(
                name: "Delegates",
                newName: "Delegate");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Units_UnitId",
                table: "Unit",
                newName: "IX_Unit_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_StoreId",
                table: "Unit",
                newName: "IX_Unit_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_PrintSignatures_PrintOrderId",
                table: "PrintSignature",
                newName: "IX_PrintSignature_PrintOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_UnitId",
                table: "Item",
                newName: "IX_Item_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Item",
                newName: "IX_Item_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProductionDetails_PrintSignatureId",
                table: "EmployeeProductionDetail",
                newName: "IX_EmployeeProductionDetail_PrintSignatureId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProductionDetails_EmployeeProductionId",
                table: "EmployeeProductionDetail",
                newName: "IX_EmployeeProductionDetail_EmployeeProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_StoreId",
                table: "Category",
                newName: "IX_Category_StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrintSize",
                table: "PrintSize",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrintSignature",
                table: "PrintSignature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProductionDetail",
                table: "EmployeeProductionDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delegate",
                table: "Delegate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Store_StoreId",
                table: "Category",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductionDetail_EmployeeProductions_EmployeeProductionId",
                table: "EmployeeProductionDetail",
                column: "EmployeeProductionId",
                principalTable: "EmployeeProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProductionDetail_PrintSignature_PrintSignatureId",
                table: "EmployeeProductionDetail",
                column: "PrintSignatureId",
                principalTable: "PrintSignature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Unit_UnitId",
                table: "Item",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineProductions_PrintSignature_PrintSignatureId",
                table: "MachineProductions",
                column: "PrintSignatureId",
                principalTable: "PrintSignature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintOrderRequiredItems_Item_ItemId",
                table: "PrintOrderRequiredItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PrintSignature_PrintOrders_PrintOrderId",
                table: "PrintSignature",
                column: "PrintOrderId",
                principalTable: "PrintOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Store_StoreId",
                table: "Unit",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Unit_UnitId",
                table: "Unit",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");
        }
    }
}
