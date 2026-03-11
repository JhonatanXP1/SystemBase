using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endpointAccess",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endpointAccess", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nameRule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nameRule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageUser = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    userName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    app = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    apm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "endpointAcces_nameRule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEndpointAccess = table.Column<int>(type: "int", nullable: false),
                    idNameRule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endpointAcces_nameRule", x => x.id);
                    table.ForeignKey(
                        name: "FK_endpointAcces_nameRule_endpointAccess_idEndpointAccess",
                        column: x => x.idEndpointAccess,
                        principalTable: "endpointAccess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_endpointAcces_nameRule_nameRule_idNameRule",
                        column: x => x.idNameRule,
                        principalTable: "nameRule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refreshTokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    tokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SessionExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agentUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idEndpointAccessNameRule = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_roles_endpointAcces_nameRule_idEndpointAccessNameRule",
                        column: x => x.idEndpointAccessNameRule,
                        principalTable: "endpointAcces_nameRule",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    scopeType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    scopeId = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
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
                table: "endpointAccess",
                columns: new[] { "id", "endpoint", "method", "permission", "status" },
                values: new object[,]
                {
                    { 1, "/auth/logout", "POST", "auth.logout.self", true },
                    { 2, "/auth/logout", "POST", "auth.logout.*", true },
                    { 3, "/auth/logout", "POST", "auth.logout.subordinate", true }
                });

            migrationBuilder.InsertData(
                table: "nameRule",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Acceso de CEO" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "code", "created", "idEndpointAccessNameRule", "name" },
                values: new object[] { 2, 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, "Gerente de Nave" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "apm", "app", "created", "imageUser", "name", "password", "userName" },
                values: new object[] { 1, "Mendez", "Diaz", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, "Jhonatan", "$argon2id$v=19$m=32768,t=3,p=2$XqPdP44Dhf7Fx6/o56X08g$+PBdv4WYvCHkLB3y90eA3Xw7RQ0ipfSFLBM8pZ0vPBY", "@adminDev" });

            migrationBuilder.InsertData(
                table: "endpointAcces_nameRule",
                columns: new[] { "id", "idEndpointAccess", "idNameRule" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "code", "created", "idEndpointAccessNameRule", "name" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, "CEO" });

            migrationBuilder.CreateIndex(
                name: "IX_endpointAcces_nameRule_idEndpointAccess",
                table: "endpointAcces_nameRule",
                column: "idEndpointAccess");

            migrationBuilder.CreateIndex(
                name: "IX_endpointAcces_nameRule_idNameRule",
                table: "endpointAcces_nameRule",
                column: "idNameRule");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_idUser",
                table: "refreshTokens",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule");

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
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "user_assignments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "endpointAcces_nameRule");

            migrationBuilder.DropTable(
                name: "endpointAccess");

            migrationBuilder.DropTable(
                name: "nameRule");
        }
    }
}
