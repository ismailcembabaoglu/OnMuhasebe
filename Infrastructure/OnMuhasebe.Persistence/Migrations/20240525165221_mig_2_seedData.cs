using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "Password", "UpdatedDate", "UpdatedUser" },
                values: new object[,]
                {
                    { new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"), new DateTime(2024, 5, 25, 16, 52, 21, 56, DateTimeKind.Utc).AddTicks(6769), "Admin", null, "icb1742@gmail.com", "Süper", true, false, "Admin", "17421742", null, null },
                    { new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"), new DateTime(2024, 5, 25, 16, 52, 21, 56, DateTimeKind.Utc).AddTicks(6804), "Admin", null, "eagledenizcilik@outlook.com.tr", "Alican", true, false, "Kartal", "Eagle0204.", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"));
        }
    }
}
