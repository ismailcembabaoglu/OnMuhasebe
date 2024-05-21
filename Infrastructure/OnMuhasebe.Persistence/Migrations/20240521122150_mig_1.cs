using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductUnderGroups_ProductUnderGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductUnderGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductUnderGroupId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "SafeBoxMotionType",
                table: "SafeBoxMotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "MotionType",
                table: "ProductMotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DiscountType",
                table: "Discounts",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerGroupId",
                table: "Customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "BankMotionType",
                table: "BankMotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CustomerGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedUser = table.Column<string>(type: "text", nullable: false),
                    UpdatedUser = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CustomerGroupName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerGroupId",
                table: "Customers",
                column: "CustomerGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerGroup_CustomerGroupId",
                table: "Customers",
                column: "CustomerGroupId",
                principalTable: "CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerGroup_CustomerGroupId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerGroup");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerGroupId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerGroupId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "SafeBoxMotionType",
                table: "SafeBoxMotions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductUnderGroupId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotionType",
                table: "ProductMotions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountType",
                table: "Discounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "BankMotionType",
                table: "BankMotions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductUnderGroupId",
                table: "Products",
                column: "ProductUnderGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductUnderGroups_ProductUnderGroupId",
                table: "Products",
                column: "ProductUnderGroupId",
                principalTable: "ProductUnderGroups",
                principalColumn: "Id");
        }
    }
}
