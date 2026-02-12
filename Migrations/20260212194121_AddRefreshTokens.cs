using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created",
                table: "user_assignments",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "refreshTokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    tokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agentUsername = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshTokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_refreshTokens_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_idUser",
                table: "refreshTokens",
                column: "idUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "user_assignments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
