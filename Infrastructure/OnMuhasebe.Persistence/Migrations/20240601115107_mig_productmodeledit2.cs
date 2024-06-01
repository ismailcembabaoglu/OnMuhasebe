using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_productmodeledit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ProductUnderGroupName",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "IsDeleted", "ProductGroupName", "UpdatedDate", "UpdatedUser" },
                values: new object[] { new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"), new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9318), "Admin", null, false, "Grupsuz", null, null });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "IsDeleted", "UnitName", "UpdatedDate", "UpdatedUser" },
                values: new object[,]
                {
                    { new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"), new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9357), "Admin", null, false, "KG", null, null },
                    { new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"), new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9367), "Admin", null, false, "Paket", null, null },
                    { new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"), new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9347), "Admin", null, false, "ADET", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9304));

            migrationBuilder.InsertData(
                table: "ProductUnderGroups",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "IsDeleted", "ProductGroupId", "ProductUnderGroupName", "UpdatedDate", "UpdatedUser" },
                values: new object[] { new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"), new DateTime(2024, 6, 1, 11, 51, 7, 346, DateTimeKind.Utc).AddTicks(9333), "Admin", null, false, new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"), "Grupsuz", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"));

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"));

            migrationBuilder.DropColumn(
                name: "ProductUnderGroupName",
                table: "Products");

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
    }
}
