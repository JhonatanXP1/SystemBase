using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class CambiosdenombreparaendpointAcces_nameRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_endpointAcces_nameRule_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropTable(
                name: "endpointAcces_nameRule");

            migrationBuilder.CreateTable(
                name: "EndpointAccessNameRule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEndpointAccess = table.Column<int>(type: "int", nullable: false),
                    idNameRule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointAccessNameRule", x => x.id);
                    table.ForeignKey(
                        name: "FK_EndpointAccessNameRule_endpointAccess_idEndpointAccess",
                        column: x => x.idEndpointAccess,
                        principalTable: "endpointAccess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndpointAccessNameRule_nameRule_idNameRule",
                        column: x => x.idNameRule,
                        principalTable: "nameRule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EndpointAccessNameRule",
                columns: new[] { "id", "idEndpointAccess", "idNameRule" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Sm+NKFz4fZcsgD8PKWl3qA$IrWL6E+1OvU91Lb7//rEVD8z1iIY5mZShJ9mhoaMxzA");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointAccessNameRule_idEndpointAccess",
                table: "EndpointAccessNameRule",
                column: "idEndpointAccess");

            migrationBuilder.CreateIndex(
                name: "IX_EndpointAccessNameRule_idNameRule",
                table: "EndpointAccessNameRule",
                column: "idNameRule");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_EndpointAccessNameRule_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule",
                principalTable: "EndpointAccessNameRule",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_EndpointAccessNameRule_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropTable(
                name: "EndpointAccessNameRule");

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
                table: "endpointAcces_nameRule",
                columns: new[] { "id", "idEndpointAccess", "idNameRule" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$IsgDx+I0WTmuXHlareHjsw$bbTQKBpZa1vv6rR3D5MYQApgyVvqX0P2aa8Dj7KgMYY");

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
    }
}
