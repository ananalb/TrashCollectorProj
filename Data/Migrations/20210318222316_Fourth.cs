using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09bf21a9-ba6a-4eb1-8d32-6375ffbd21aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9169202-a7ea-4a1e-9c1d-6439208ab318");

            migrationBuilder.CreateTable(
                name: "Anonymous",
                columns: table => new
                {
                    AnonymousId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anonymous", x => x.AnonymousId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27ec8bbe-c65a-4cb2-881d-6cd3411fb078", "8b51862e-aa26-46e3-a902-a8d40cf25dd9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43521a4e-6574-4024-bc78-ae500f1c7b41", "6c98e355-98c8-4cb9-8764-59e2448c8170", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anonymous");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27ec8bbe-c65a-4cb2-881d-6cd3411fb078");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43521a4e-6574-4024-bc78-ae500f1c7b41");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09bf21a9-ba6a-4eb1-8d32-6375ffbd21aa", "fc6d6aba-f43f-4fce-98ac-9186bd58aebf", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9169202-a7ea-4a1e-9c1d-6439208ab318", "616adc05-3f20-464f-a639-13373924496a", "Employee", "EMPLOYEE" });
        }
    }
}
