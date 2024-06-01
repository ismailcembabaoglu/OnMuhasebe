using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_Kdv_SeedData_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kdvs",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "IsDeleted", "KdvName", "KdvRatio", "UpdatedDate", "UpdatedUser" },
                values: new object[,]
                {
                    { new Guid("0924a136-4b38-42eb-ad09-7b92f1303b8a"), new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3325), "Admin", null, false, "%20", 20m, null, null },
                    { new Guid("71cc7301-cae0-4937-a1b3-b7697291a176"), new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3336), "Admin", null, false, "%0", 0m, null, null },
                    { new Guid("a9fd0162-8f72-4d24-accc-1b0c1ec494b4"), new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3312), "Admin", null, false, "%18", 18m, null, null }
                });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3297));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 30, 48, 800, DateTimeKind.Utc).AddTicks(3225));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("0924a136-4b38-42eb-ad09-7b92f1303b8a"));

            migrationBuilder.DeleteData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("71cc7301-cae0-4937-a1b3-b7697291a176"));

            migrationBuilder.DeleteData(
                table: "Kdvs",
                keyColumn: "Id",
                keyValue: new Guid("a9fd0162-8f72-4d24-accc-1b0c1ec494b4"));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: new Guid("3342d171-222f-48bd-901d-17fb7e48d4eb"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "ProductUnderGroups",
                keyColumn: "Id",
                keyValue: new Guid("c340b1d5-f2fe-4f0c-9d4f-511f78a8643c"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("80b9d90c-c1bb-41b5-9ff3-2e0ca28d64fa"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b08f5c83-252f-4629-9ec0-65eadfe4c0f1"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("bd703370-8093-4aa3-9da6-72a1b4a701a5"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"),
                column: "CreateDate",
                value: new DateTime(2024, 6, 1, 13, 15, 39, 144, DateTimeKind.Utc).AddTicks(7776));
        }
    }
}
