using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAgregator.API.Migrations
{
    public partial class NoHashChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "tony");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "black");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "6DHHak7oYC9Y/N77aihlPMpIKmvz/pLlwto8g9pUlhs=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "DN/m6zksW/8vydt2Ak9yNWlET4jsTsRKhxEzI1w2uWg=");
        }
    }
}
