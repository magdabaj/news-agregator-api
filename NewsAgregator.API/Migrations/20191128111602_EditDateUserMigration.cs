using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAgregator.API.Migrations
{
    public partial class EditDateUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                column: "EditDate",
                value: new DateTimeOffset(new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("af1113cb-2c29-44af-b760-91dd7e852422"),
                column: "EditDate",
                value: new DateTimeOffset(new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "/CxfGcqfcYwg8usdED6FyHIuqg5SqpVvXddqKtoQfHo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "2SQs4zYRK6BpFix4gy5hkTpwmzqTeNg1CvDGrZCOiWk=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                column: "EditDate",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("af1113cb-2c29-44af-b760-91dd7e852422"),
                column: "EditDate",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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
    }
}
