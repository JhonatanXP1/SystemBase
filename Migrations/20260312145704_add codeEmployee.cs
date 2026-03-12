using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class addcodeEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codeEmployee",
                table: "user_assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "user_assignments",
                keyColumn: "id",
                keyValue: 1,
                column: "codeEmployee",
                value: "N1-12");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$IsgDx+I0WTmuXHlareHjsw$bbTQKBpZa1vv6rR3D5MYQApgyVvqX0P2aa8Dj7KgMYY");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codeEmployee",
                table: "user_assignments");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ZnUskIpbF1AMN0PqB1eWAg$wDgDdbCTZdJP5QHiTEn/Y5cjkvb2jRKnZYKBqoe2Dfo");
        }
    }
}
