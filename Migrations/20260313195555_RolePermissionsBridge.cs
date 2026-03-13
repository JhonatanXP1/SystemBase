using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class RolePermissionsBridge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndpointAccessNameRule_endpointAccess_idEndpointAccess",
                table: "EndpointAccessNameRule");

            migrationBuilder.DropForeignKey(
                name: "FK_EndpointAccessNameRule_nameRule_idNameRule",
                table: "EndpointAccessNameRule");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_EndpointAccessNameRule_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nameRule",
                table: "nameRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndpointAccessNameRule",
                table: "EndpointAccessNameRule");

            migrationBuilder.DropColumn(
                name: "idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "nameRule",
                newName: "nameRules");

            migrationBuilder.RenameTable(
                name: "EndpointAccessNameRule",
                newName: "endpointAccessNameRules");

            migrationBuilder.RenameIndex(
                name: "IX_EndpointAccessNameRule_idNameRule",
                table: "endpointAccessNameRules",
                newName: "IX_endpointAccessNameRules_idNameRule");

            migrationBuilder.RenameIndex(
                name: "IX_EndpointAccessNameRule_idEndpointAccess",
                table: "endpointAccessNameRules",
                newName: "IX_endpointAccessNameRules_idEndpointAccess");

            migrationBuilder.AddColumn<int>(
                name: "idRole",
                table: "endpointAccessNameRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_nameRules",
                table: "nameRules",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_endpointAccessNameRules",
                table: "endpointAccessNameRules",
                column: "id");

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 1,
                column: "idRole",
                value: 1);

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 2,
                column: "idRole",
                value: 1);

            migrationBuilder.InsertData(
                table: "endpointAccessNameRules",
                columns: new[] { "id", "idEndpointAccess", "idNameRule", "idRole" },
                values: new object[] { 3, 1, 1, 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$hd1fjpBnMXRBxS9KBcgwFg$QTTiZlJkcuPJurB/Vn8tTid4Ekl0CykTDvseKCG5MXY");

            migrationBuilder.CreateIndex(
                name: "IX_endpointAccessNameRules_idRole_idEndpointAccess_idNameRule",
                table: "endpointAccessNameRules",
                columns: new[] { "idRole", "idEndpointAccess", "idNameRule" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_endpointAccessNameRules_endpointAccess_idEndpointAccess",
                table: "endpointAccessNameRules",
                column: "idEndpointAccess",
                principalTable: "endpointAccess",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_endpointAccessNameRules_nameRules_idNameRule",
                table: "endpointAccessNameRules",
                column: "idNameRule",
                principalTable: "nameRules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_endpointAccessNameRules_roles_idRole",
                table: "endpointAccessNameRules",
                column: "idRole",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_endpointAccessNameRules_endpointAccess_idEndpointAccess",
                table: "endpointAccessNameRules");

            migrationBuilder.DropForeignKey(
                name: "FK_endpointAccessNameRules_nameRules_idNameRule",
                table: "endpointAccessNameRules");

            migrationBuilder.DropForeignKey(
                name: "FK_endpointAccessNameRules_roles_idRole",
                table: "endpointAccessNameRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nameRules",
                table: "nameRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_endpointAccessNameRules",
                table: "endpointAccessNameRules");

            migrationBuilder.DropIndex(
                name: "IX_endpointAccessNameRules_idRole_idEndpointAccess_idNameRule",
                table: "endpointAccessNameRules");

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "idRole",
                table: "endpointAccessNameRules");

            migrationBuilder.RenameTable(
                name: "nameRules",
                newName: "nameRule");

            migrationBuilder.RenameTable(
                name: "endpointAccessNameRules",
                newName: "EndpointAccessNameRule");

            migrationBuilder.RenameIndex(
                name: "IX_endpointAccessNameRules_idNameRule",
                table: "EndpointAccessNameRule",
                newName: "IX_EndpointAccessNameRule_idNameRule");

            migrationBuilder.RenameIndex(
                name: "IX_endpointAccessNameRules_idEndpointAccess",
                table: "EndpointAccessNameRule",
                newName: "IX_EndpointAccessNameRule_idEndpointAccess");

            migrationBuilder.AddColumn<int>(
                name: "idEndpointAccessNameRule",
                table: "roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_nameRule",
                table: "nameRule",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndpointAccessNameRule",
                table: "EndpointAccessNameRule",
                column: "id");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "idEndpointAccessNameRule",
                value: 1);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "idEndpointAccessNameRule",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Md7htI5T4MstYssYBHk3sw$HWnz7XTNLjv8wn8GljlKCA8Cf4P9YinQ44MmocUHx1s");

            migrationBuilder.CreateIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule");

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointAccessNameRule_endpointAccess_idEndpointAccess",
                table: "EndpointAccessNameRule",
                column: "idEndpointAccess",
                principalTable: "endpointAccess",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndpointAccessNameRule_nameRule_idNameRule",
                table: "EndpointAccessNameRule",
                column: "idNameRule",
                principalTable: "nameRule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_EndpointAccessNameRule_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule",
                principalTable: "EndpointAccessNameRule",
                principalColumn: "id");
        }
    }
}
