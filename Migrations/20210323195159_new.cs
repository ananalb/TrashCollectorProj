using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f85bf2e-83fb-45f6-bf68-319576484ccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4161052-8729-470e-ac5b-46caf1328eab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45dd04a3-97b7-4995-b449-6142c1b9f7f6", "8229e3ce-c813-4cbc-ad9d-0b98508481a8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b926386-4783-4a33-b4a8-ed77c2df8121", "f35942f8-333c-4938-9b93-632154b1b527", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45dd04a3-97b7-4995-b449-6142c1b9f7f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b926386-4783-4a33-b4a8-ed77c2df8121");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4161052-8729-470e-ac5b-46caf1328eab", "e7e220f4-00ec-4d93-99b2-9485aca710a1", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f85bf2e-83fb-45f6-bf68-319576484ccd", "e3ce8a25-4230-4402-aadf-16a5795eb04d", "Employee", "EMPLOYEE" });
        }
    }
}
