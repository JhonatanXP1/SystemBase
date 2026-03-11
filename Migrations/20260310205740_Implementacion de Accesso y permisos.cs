using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class ImplementaciondeAccessoypermisos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idEndpointAccessNameRule",
                table: "roles",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$/O+HlgoggAT+PMILYDprjw$RVI2Ek3A2G+O94WbtDV9bGgxBpRYDWgj45NNqvZJhjo");

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
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule");

            migrationBuilder.CreateIndex(
                name: "IX_endpointAcces_nameRule_idEndpointAccess",
                table: "endpointAcces_nameRule",
                column: "idEndpointAccess");

            migrationBuilder.CreateIndex(
                name: "IX_endpointAcces_nameRule_idNameRule",
                table: "endpointAcces_nameRule",
                column: "idNameRule");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_endpointAcces_nameRule_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule",
                principalTable: "endpointAcces_nameRule",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_endpointAcces_nameRule_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropTable(
                name: "endpointAcces_nameRule");

            migrationBuilder.DropTable(
                name: "endpointAccess");

            migrationBuilder.DropTable(
                name: "nameRule");

            migrationBuilder.DropIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$akKLs7tI7KEJBVdyCnQuPQ$AngY0fmU55hp5gRNcOmYu7zLnTT3n13uYknNB5MUbmY");
        }
    }
}
