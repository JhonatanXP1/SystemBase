using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteAtAndExpandScopeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleteAt",
                table: "users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleteAt",
                table: "userAssignments",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleteAt",
                table: "roles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleteAt",
                table: "nameRules",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleteAt",
                table: "endpointAccessNameRules",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleteAt",
                table: "endpointAccess",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 1,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 2,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 3,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 4,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 5,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 6,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 7,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 1,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 2,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 3,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "nameRules",
                keyColumn: "id",
                keyValue: 1,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "nameRules",
                keyColumn: "id",
                keyValue: 2,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "deleteAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "deleteAt", "idNameRule", "name" },
                values: new object[] { null, 2, "Gerente General" });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "deleteAt", "scopeType" },
                values: new object[] { null, "company" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "deleteAt", "password" },
                values: new object[] { null, "$argon2id$v=19$m=32768,t=3,p=2$PhJOxxRpBwnWJy9fc32tnw$vgnGvHyId5CNzFBxRBWMOsAGXIGofr1sWxoLzabwxCM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleteAt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "deleteAt",
                table: "userAssignments");

            migrationBuilder.DropColumn(
                name: "deleteAt",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "deleteAt",
                table: "nameRules");

            migrationBuilder.DropColumn(
                name: "deleteAt",
                table: "endpointAccessNameRules");

            migrationBuilder.DropColumn(
                name: "deleteAt",
                table: "endpointAccess");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "idNameRule", "name" },
                values: new object[] { null, "Gerente de Nave" });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 1,
                column: "scopeType",
                value: "COMPANY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$lMDcgm+eUiZUh7yXUSnitQ$Zz6aI2LmG5ImR4BMBnyYU8EcB7IYK9ixxN9zopTN0yI");
        }
    }
}
