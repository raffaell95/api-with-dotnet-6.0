using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class AddDataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "55c217e5-9e6a-461c-8373-906bab4c3c23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f3b4e3c8-26ec-4a62-8129-24abdd0f4969");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb79043-adfb-4788-9f04-6848fc64d83a", "AQAAAAEAACcQAAAAEIKu46Ky4Lbtydt4fuug2989NK/mXvw8bnvF6DW3tXq6YsKTP15OizMAI8j1e4wnsw==", "94c28479-9813-4640-9d37-a346c7748e13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "d3d88a53-e6fc-4e7c-879f-ae201a28e5be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "8d4c45f3-a45a-4dab-8210-69666ec78a8e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d60ec09-5527-43b1-b7a4-9395aa1fca6f", "AQAAAAEAACcQAAAAEEd0modG8F7HoJ03/oN9eXr/Y+1i6DI7hPlj80VYRDYy8YeR+CaNX4sDBzyqwnlWCg==", "08873e6c-4cf2-4a0b-ba89-977cf35d943a" });
        }
    }
}
