using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace website_backend.Migrations
{
    public partial class WebsiteDbAddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title" },
                values: new object[] { 1, "this is dev log one", "Dev Log 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title" },
                values: new object[] { 2, "this is dev log two", "Dev Log 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title" },
                values: new object[] { 3, "this is dev log three", "Dev Log 3" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 1, "this is better than anything I could ever do", 1, "Really cool!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 2, "lorem ipsum is a sample text who cares tho", 1, "Lorem " });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 3, "lorem ipsum is a sample text who cares tho", 1, "Lorem Log 3" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 4, "this is dev log one", 2, "Really cool!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 5, "this is dev log two", 2, "Dev Lorem 2" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 6, "lorem ipsum is a sample text who cares tho", 2, "Lorem Log 3" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 7, "So this is how you do it!", 3, "Really cool!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 8, "I could do way better", 3, "Kinda sucks" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "PostId", "Title" },
                values: new object[] { 9, "lorem ipsum is a sample text who cares tho", 3, "Lorem ipsum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
