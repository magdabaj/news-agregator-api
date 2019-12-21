using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAgregator.API.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagsArticles",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsArticles", x => new { x.ArticleId, x.TagId });
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                columns: new[] { "Title", "Url" },
                values: new object[] { "An open source React library to power production-ready animations.", "https://www.framer.com/motion/" });

            migrationBuilder.InsertData(
                table: "TagsArticles",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[,]
                {
                    { new Guid("af1113cb-2c29-44af-b760-91dd7e852422"), new Guid("a8bb30d3-4e33-41f3-8725-126ba71a8bd6") },
                    { new Guid("af1113cb-2c29-44af-b760-91dd7e852422"), new Guid("1f76c6e7-2933-435c-bacc-1a8092e75c20") },
                    { new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"), new Guid("a8bb30d3-4e33-41f3-8725-126ba71a8bd6") },
                    { new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"), new Guid("bf4d4a26-036d-485d-bfc8-75756463cd5e") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                column: "Password",
                value: "1GpdmXdq4HiedoUd+ELEBHZqnHS0jt2qJnC9P9WQeyw=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                column: "Password",
                value: "A74jxjId8wm5i6EndSx0qvsTEVTDM2ewuNiK1mjukLw=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagsArticles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                columns: new[] { "Title", "Url" },
                values: new object[] { "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React", "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2" });

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
    }
}
