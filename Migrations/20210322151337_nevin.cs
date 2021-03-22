using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class nevin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ea02d23-855d-403d-ae66-5196bef978a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b39aee19-3df8-4527-b960-eff15c0cc440");

            migrationBuilder.DropColumn(
                name: "ExtraPickupDay",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PickupDay",
                table: "Employees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickupDay",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa419a77-eb2d-4cd6-aabc-0905fc3804da", "733ce02f-cec9-4efc-9e1f-7a690e349c8c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00b1c464-11b7-449c-afb5-db40bb8da507", "f61bc645-b612-41ce-83bd-db0e10c44a1e", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00b1c464-11b7-449c-afb5-db40bb8da507");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa419a77-eb2d-4cd6-aabc-0905fc3804da");

            migrationBuilder.AddColumn<string>(
                name: "ExtraPickupDay",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickupDay",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PickupDay",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ea02d23-855d-403d-ae66-5196bef978a2", "87529107-fc0a-4582-982d-768f40bb6e22", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b39aee19-3df8-4527-b960-eff15c0cc440", "6e86b2a2-00cd-4c1a-b992-5097c0e74cc6", "Employee", "EMPLOYEE" });
        }
    }
}
