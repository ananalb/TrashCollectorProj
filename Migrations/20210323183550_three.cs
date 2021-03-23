using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bdfc037-932a-451e-a560-a76a6a1be826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b48b95ae-3a76-4080-bf70-c6215690380d");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExtraPickupDay",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndSuspensionDay",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartSuspensionDay",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4161052-8729-470e-ac5b-46caf1328eab", "e7e220f4-00ec-4d93-99b2-9485aca710a1", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f85bf2e-83fb-45f6-bf68-319576484ccd", "e3ce8a25-4230-4402-aadf-16a5795eb04d", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f85bf2e-83fb-45f6-bf68-319576484ccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4161052-8729-470e-ac5b-46caf1328eab");

            migrationBuilder.DropColumn(
                name: "EndSuspensionDay",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StartSuspensionDay",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExtraPickupDay",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bdfc037-932a-451e-a560-a76a6a1be826", "a2dbd059-75ff-4b55-b533-7b19b221ee93", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b48b95ae-3a76-4080-bf70-c6215690380d", "d06ae0da-a929-4b49-931d-3296f098c914", "Employee", "EMPLOYEE" });
        }
    }
}
