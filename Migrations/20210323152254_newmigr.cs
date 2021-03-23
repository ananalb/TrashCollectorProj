using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class newmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0df208bb-4d35-475e-97bb-d4fc862ea80c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15cff204-38b1-4490-a5cd-a826c0de194e");

            migrationBuilder.AlterColumn<string>(
                name: "PickupDay",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bdfc037-932a-451e-a560-a76a6a1be826", "a2dbd059-75ff-4b55-b533-7b19b221ee93", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b48b95ae-3a76-4080-bf70-c6215690380d", "d06ae0da-a929-4b49-931d-3296f098c914", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PickupDay",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15cff204-38b1-4490-a5cd-a826c0de194e", "3d1bdb98-a28c-4ff7-b38b-8e18a8944ec2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0df208bb-4d35-475e-97bb-d4fc862ea80c", "cc88a06c-2049-414d-9785-1c7c8f2ae2ab", "Employee", "EMPLOYEE" });
        }
    }
}
