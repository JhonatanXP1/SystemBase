using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserAssignmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_assignments");

            migrationBuilder.CreateTable(
                name: "userAssignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    codeEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    scopeType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    scopeId = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAssignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_userAssignments_roles_idRole",
                        column: x => x.idRole,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userAssignments_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "userAssignments",
                columns: new[] { "id", "codeEmployee", "created", "idRole", "idUser", "isActive", "scopeId", "scopeType" },
                values: new object[] { 1, "N1-12", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1, true, null, "COMPANY" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$/MewIZ3sC7IjvOXMU3qCvQ$t4d7QjxNME7MVKrtKKXfOvgHuXbtRnmba9FmqZi16Sg");

            migrationBuilder.CreateIndex(
                name: "IX_userAssignments_idRole",
                table: "userAssignments",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_userAssignments_idUser",
                table: "userAssignments",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_userAssignments_scopeId_scopeType_idUser_idRole",
                table: "userAssignments",
                columns: new[] { "scopeId", "scopeType", "idUser", "idRole" },
                unique: true,
                filter: "[scopeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userAssignments");

            migrationBuilder.CreateTable(
                name: "user_assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    codeEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    scopeId = table.Column<int>(type: "int", nullable: true),
                    scopeType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_assignments_roles_idRole",
                        column: x => x.idRole,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_assignments_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user_assignments",
                columns: new[] { "id", "codeEmployee", "created", "idRole", "idUser", "isActive", "scopeId", "scopeType" },
                values: new object[] { 1, "N1-12", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1, true, null, "COMPANY" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$kPJEMypos5OIqbP4EPCVug$oJ9vorLoukSumBSTLRZmIrmU5aeJNN6IzPmSL+34QGM");

            migrationBuilder.CreateIndex(
                name: "IX_user_assignments_idRole",
                table: "user_assignments",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_user_assignments_idUser",
                table: "user_assignments",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_user_assignments_scopeId_scopeType_idUser_idRole",
                table: "user_assignments",
                columns: new[] { "scopeId", "scopeType", "idUser", "idRole" },
                unique: true,
                filter: "[scopeId] IS NOT NULL");
        }
    }
}
