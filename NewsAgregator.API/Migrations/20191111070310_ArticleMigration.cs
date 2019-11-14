using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAgregator.API.Migrations
{
    public partial class ArticleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a8bb30d3-4e33-41f3-8725-126ba71a8bd6"), "react" },
                    { new Guid("bf4d4a26-036d-485d-bfc8-75756463cd5e"), "css" },
                    { new Guid("565ccc30-95f5-472d-946e-5f5e5d38267d"), "redux" },
                    { new Guid("7b19adf3-b384-4d7b-91bd-680262d3d0f6"), "saga" },
                    { new Guid("b5f64544-3540-4a2b-82bb-0cf623b42173"), "javascript" },
                    { new Guid("1f76c6e7-2933-435c-bacc-1a8092e75c20"), "other" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"), new DateTimeOffset(new DateTime(1980, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "i.am.iron.man@slash.com", "Tony", "Stark", "LOBiaLjEX2Si8sVF0IQnvSFE0iimPPC6P43MHVlceO0=" },
                    { new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"), new DateTimeOffset(new DateTime(1982, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "black.widow@slash.com", "Black", "Widow", "/qjIg52/t9c5r4WW10kGSw+frkld5mcovGWI9A3aZJI=" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Title", "Url", "UserEmail", "UserId" },
                values: new object[] { new Guid("af1113cb-2c29-44af-b760-91dd7e852422"), "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React", "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2", "i.am.iron.man@slash.com", new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17") });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Title", "Url", "UserEmail", "UserId" },
                values: new object[] { new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"), "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React", "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2", "black.widow@slash.com", new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b") });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
