using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_customerGroup_seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerGroups",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "CustomerGroupName", "Decription", "IsDeleted", "UpdatedDate", "UpdatedUser" },
                values: new object[] { new Guid("e767d4b3-88f7-4af6-932d-431bbfd95c3f"), new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8116), "Admin", "Grupsuz", null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("0924a136-4b38-42eb-ad09-7b92f1303b8a"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("71cc7301-cae0-4937-a1b3-b7697291a176"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("a9fd0162-8f72-4d24-accc-1b0c1ec494b4"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 56, 24, 351, DateTimeKind.Utc).AddTicks(8091));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: new Guid("e767d4b3-88f7-4af6-932d-431bbfd95c3f"));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("0924a136-4b38-42eb-ad09-7b92f1303b8a"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("71cc7301-cae0-4937-a1b3-b7697291a176"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("a9fd0162-8f72-4d24-accc-1b0c1ec494b4"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 4, 10, 53, 40, 952, DateTimeKind.Utc).AddTicks(5652));
        }
    }
}
