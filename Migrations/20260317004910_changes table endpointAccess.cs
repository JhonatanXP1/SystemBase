using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class changestableendpointAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 1,
                column: "permission",
                value: "auth.logout.*");

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 2,
                column: "permission",
                value: "auth.logout.subordinate");

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 3,
                column: "idEndpointAccess",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$kPJEMypos5OIqbP4EPCVug$oJ9vorLoukSumBSTLRZmIrmU5aeJNN6IzPmSL+34QGM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 1,
                column: "permission",
                value: "auth.logout.self");

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 2,
                column: "permission",
                value: "auth.logout.*");

            migrationBuilder.InsertData(
                table: "endpointAccess",
                columns: new[] { "id", "endpoint", "method", "permission", "status" },
                values: new object[] { 3, "/auth/logout", "POST", "auth.logout.subordinate", true });

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 3,
                column: "idEndpointAccess",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$hd1fjpBnMXRBxS9KBcgwFg$QTTiZlJkcuPJurB/Vn8tTid4Ekl0CykTDvseKCG5MXY");
        }
    }
}
