using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAgregator.API.Migrations
{
    public partial class EditDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "EPIvEvr9Sj8wbmWDkif5FszoqJV3SPTkKxrGvOrA+78=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "v/G+R+b+Vf2s1GXBTU6/WjsHv9QnJnx+ucdZGQvR754=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "DITP3wE9XnIA8McdqVl3vOiiy8oXDnyYTW6tTO413mc=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "j34G08KgZz0uyM5kvQRMkODRPaUwJOgq5Gd7DPuZrKE=");
        }
    }
}
