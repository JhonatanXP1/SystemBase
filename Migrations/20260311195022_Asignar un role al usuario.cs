using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class Asignarunrolealusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_assignments_scopeId_scopeType_idUser_idRole",
                table: "user_assignments");

            migrationBuilder.AlterColumn<int>(
                name: "scopeId",
                table: "user_assignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "user_assignments",
                columns: new[] { "id", "created", "idRole", "idUser", "scopeId", "scopeType" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1, null, "COMPANY" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$CTSileQZE8aFOpkqzdI2IA$n1LOdL1Rgbnvf7+qNUiaE2Nr1n0EXOckqZsyNJCCk+I");

            migrationBuilder.CreateIndex(
                name: "IX_user_assignments_scopeId_scopeType_idUser_idRole",
                table: "user_assignments",
                columns: new[] { "scopeId", "scopeType", "idUser", "idRole" },
                unique: true,
                filter: "[scopeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_assignments_scopeId_scopeType_idUser_idRole",
                table: "user_assignments");

            migrationBuilder.DeleteData(
                table: "user_assignments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "scopeId",
                table: "user_assignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$XqPdP44Dhf7Fx6/o56X08g$+PBdv4WYvCHkLB3y90eA3Xw7RQ0ipfSFLBM8pZ0vPBY");

            migrationBuilder.CreateIndex(
                name: "IX_user_assignments_scopeId_scopeType_idUser_idRole",
                table: "user_assignments",
                columns: new[] { "scopeId", "scopeType", "idUser", "idRole" },
                unique: true);
        }
    }
}
