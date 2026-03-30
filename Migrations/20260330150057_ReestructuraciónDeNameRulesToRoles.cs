using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class ReestructuraciónDeNameRulesToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_endpointAccessNameRules_idEndpointAccessNameRule",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "idEndpointAccessNameRule",
                table: "roles",
                newName: "idNameRule");

            migrationBuilder.RenameIndex(
                name: "IX_roles_idEndpointAccessNameRule",
                table: "roles",
                newName: "IX_roles_idNameRule");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "idNameRule",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$yvxlF4xWVVqh4ley186RQA$f4kL0X3xk/CpynteN4wXoU1egISB780J9EBGz/gBgiA");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_nameRules_idNameRule",
                table: "roles",
                column: "idNameRule",
                principalTable: "nameRules",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_nameRules_idNameRule",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "idNameRule",
                table: "roles",
                newName: "idEndpointAccessNameRule");

            migrationBuilder.RenameIndex(
                name: "IX_roles_idNameRule",
                table: "roles",
                newName: "IX_roles_idEndpointAccessNameRule");

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

            migrationBuilder.AddForeignKey(
                name: "FK_roles_endpointAccessNameRules_idEndpointAccessNameRule",
                table: "roles",
                column: "idEndpointAccessNameRule",
                principalTable: "endpointAccessNameRules",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
