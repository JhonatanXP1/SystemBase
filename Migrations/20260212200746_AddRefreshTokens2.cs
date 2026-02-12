using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokens2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "agentUsername",
                table: "refreshTokens",
                newName: "agentUserName");

            migrationBuilder.RenameColumn(
                name: "IPAddress",
                table: "refreshTokens",
                newName: "ipAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ipAddress",
                table: "refreshTokens",
                newName: "IPAddress");

            migrationBuilder.RenameColumn(
                name: "agentUserName",
                table: "refreshTokens",
                newName: "agentUsername");
        }
    }
}
