using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_productmotion_edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "KdvId",
                table: "ProductMotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountRate",
                table: "ProductMotions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "Kdv",
                table: "ProductMotions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: new Guid("e767d4b3-88f7-4af6-932d-431bbfd95c3f"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("0924a136-4b38-42eb-ad09-7b92f1303b8a"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("71cc7301-cae0-4937-a1b3-b7697291a176"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("a9fd0162-8f72-4d24-accc-1b0c1ec494b4"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5546));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5538));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 7, 12, 48, 22, 756, DateTimeKind.Utc).AddTicks(5476));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kdv",
                table: "ProductMotions");

            migrationBuilder.AlterColumn<Guid>(
                name: "KdvId",
                table: "ProductMotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountRate",
                table: "ProductMotions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: new Guid("e767d4b3-88f7-4af6-932d-431bbfd95c3f"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("0924a136-4b38-42eb-ad09-7b92f1303b8a"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("71cc7301-cae0-4937-a1b3-b7697291a176"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("a9fd0162-8f72-4d24-accc-1b0c1ec494b4"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 5, 23, 56, 4, 839, DateTimeKind.Utc).AddTicks(7080));
        }
    }
}
