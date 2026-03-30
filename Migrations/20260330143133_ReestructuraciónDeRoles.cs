using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class ReestructuraciónDeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_endpointAccessNameRules_roles_idRole",
                table: "endpointAccessNameRules");

            migrationBuilder.DropIndex(
                name: "IX_endpointAccessNameRules_idRole_idEndpointAccess_idNameRule",
                table: "endpointAccessNameRules");

            migrationBuilder.DropColumn(
                name: "idRole",
                table: "endpointAccessNameRules");

            migrationBuilder.AlterColumn<string>(
                name: "codeEmployee",
                table: "userAssignments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idEndpointAccessNameRule",
                table: "roles",
                type: "int",
                nullable: true);

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
                value: 3);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$A4/4Xk85led/dEpJySW+ag$1p/h6t0WvqqKKpKGKeI70BJ4pv/F8PhrL3ZaQFfTWac");

            migrationBuilder.CreateIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_endpointAccessNameRules_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule",
                principalTable: "endpointAccessNameRules",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_endpointAccessNameRules_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.AlterColumn<string>(
                name: "codeEmployee",
                table: "userAssignments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idRole",
                table: "endpointAccessNameRules",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 3,
                column: "idRole",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$/MewIZ3sC7IjvOXMU3qCvQ$t4d7QjxNME7MVKrtKKXfOvgHuXbtRnmba9FmqZi16Sg");

            migrationBuilder.CreateIndex(
                name: "IX_endpointAccessNameRules_idRole_idEndpointAccess_idNameRule",
                table: "endpointAccessNameRules",
                columns: new[] { "idRole", "idEndpointAccess", "idNameRule" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_endpointAccessNameRules_roles_idRole",
                table: "endpointAccessNameRules",
                column: "idRole",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
