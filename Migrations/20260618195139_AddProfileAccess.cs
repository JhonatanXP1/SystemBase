using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profileAccess",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    profileTable = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    canRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    canWrite = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profileAccess", x => x.id);
                    table.ForeignKey(
                        name: "FK_profileAccess_roles_idRole",
                        column: x => x.idRole,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$lMDcgm+eUiZUh7yXUSnitQ$Zz6aI2LmG5ImR4BMBnyYU8EcB7IYK9ixxN9zopTN0yI");

            migrationBuilder.CreateIndex(
                name: "IX_profileAccess_idRole_profileTable",
                table: "profileAccess",
                columns: new[] { "idRole", "profileTable" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profileAccess");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$bhkcNveySO7GCFRIplR10g$3bIVoeiWRchUxJjRwIF2mteIepZzTzc/6VhhOhMcvV4");
        }
    }
}
