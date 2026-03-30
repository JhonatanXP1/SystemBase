using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class ReestructuraciondeBasededatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "endpointAccess",
                columns: new[] { "id", "endpoint", "method", "permission", "status" },
                values: new object[,]
                {
                    { 3, "/auth/access", "GET", "auth.access.*", true },
                    { 4, "/auth/access", "GET", "auth.access.subordinate", true },
                    { 5, "/user", "GET", "users.read.self", true },
                    { 6, "/user", "GET", "users.read.*", true },
                    { 7, "/user", "GET", "user.read.subordinate", true }
                });

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 2,
                column: "idEndpointAccess",
                value: 3);

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 3,
                column: "idEndpointAccess",
                value: 6);

            migrationBuilder.InsertData(
                table: "nameRules",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Accesos de Gerente N-1" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$bhkcNveySO7GCFRIplR10g$3bIVoeiWRchUxJjRwIF2mteIepZzTzc/6VhhOhMcvV4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "nameRules",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 2,
                column: "idEndpointAccess",
                value: 2);

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
                value: "$argon2id$v=19$m=32768,t=3,p=2$yvxlF4xWVVqh4ley186RQA$f4kL0X3xk/CpynteN4wXoU1egISB780J9EBGz/gBgiA");
        }
    }
}
