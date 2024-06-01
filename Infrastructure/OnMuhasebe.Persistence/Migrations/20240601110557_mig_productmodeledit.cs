using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_productmodeledit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGroupId",
                table: "Products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 11, 5, 57, 109, DateTimeKind.Utc).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 11, 5, 57, 109, DateTimeKind.Utc).AddTicks(1143));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGroupId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 5, 25, 17, 45, 7, 531, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 5, 25, 17, 45, 7, 531, DateTimeKind.Utc).AddTicks(1429));
        }
    }
}
