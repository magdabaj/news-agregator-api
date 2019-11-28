using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAgregator.API.Migrations
{
    public partial class AddedDateUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AddedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EditDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                column: "AddedDate",
                value: new DateTimeOffset(new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("af1113cb-2c29-44af-b760-91dd7e852422"),
                column: "AddedDate",
                value: new DateTimeOffset(new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "WU9OPE04S07CjUNMj1UIktCtwOWhvxSSy0YNXbTlvu8=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "2OZeXZPNR3Zbp2wExbngT23ii8dDmb2N0z9i91f36Jk=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "ntIp25efxN1TX9chOf7GcFXGGqakaf0dXykZDP7VZq4=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "ONFjcBE+8294bSPurZgxSCnqZ3ZghninuobCV8Y48xA=");
        }
    }
}
