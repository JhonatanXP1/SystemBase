using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserEndpointsAndRoleNameRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 7,
                column: "permission",
                value: "users.read.subordinate");

            migrationBuilder.InsertData(
                table: "endpointAccess",
                columns: new[] { "id", "deleteAt", "endpoint", "method", "permission", "status" },
                values: new object[,]
                {
                    { 8, null, "/user/{id}", "GET", "users.read.self", true },
                    { 9, null, "/user/{id}", "GET", "users.read.subordinate", true },
                    { 10, null, "/user/{id}", "GET", "users.read.*", true },
                    { 11, null, "/user", "POST", "users.create.*", true },
                    { 12, null, "/user/{id}", "PUT", "users.update.self", true },
                    { 13, null, "/user/{id}", "PUT", "users.update.subordinate", true },
                    { 14, null, "/user/{id}", "PUT", "users.update.*", true },
                    { 15, null, "/user/{id}", "DELETE", "users.delete.*", true },
                    { 16, null, "/user/{id}/status", "PATCH", "users.status.*", true },
                    { 17, null, "/user/{id}/assignment", "POST", "users.assignment.create.*", true },
                    { 18, null, "/user/{id}/assignment/{assignmentId}", "DELETE", "users.assignment.delete.*", true },
                    { 19, null, "/user/{id}/password", "PUT", "users.password.self", true },
                    { 20, null, "/user/{id}/password", "PUT", "users.password.*", true },
                    { 21, null, "/user/{id}/assignments", "GET", "users.assignment.read.self", true },
                    { 22, null, "/user/{id}/assignments", "GET", "users.assignment.read.subordinate", true },
                    { 23, null, "/user/{id}/assignments", "GET", "users.assignment.read.*", true },
                    { 24, null, "/auth/logout", "POST", "auth.logout.self", true },
                    { 25, null, "/auth/access", "GET", "auth.access.self", true }
                });

            migrationBuilder.InsertData(
                table: "endpointAccessNameRules",
                columns: new[] { "id", "deleteAt", "idEndpointAccess", "idNameRule" },
                values: new object[,]
                {
                    { 13, null, 1, 2 },
                    { 14, null, 3, 2 },
                    { 15, null, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "nameRules",
                columns: new[] { "id", "deleteAt", "name" },
                values: new object[,]
                {
                    { 3, null, "Accesos de Supervisor" },
                    { 4, null, "Accesos de Coordinador" },
                    { 5, null, "Accesos de Empleado" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$4Dz7niopJiq3dWHvKNFNpw$nBw17x935TrghYRZde4si8EdbVBePQKUI2hu6TFgPM8");

            migrationBuilder.InsertData(
                table: "endpointAccessNameRules",
                columns: new[] { "id", "deleteAt", "idEndpointAccess", "idNameRule" },
                values: new object[,]
                {
                    { 4, null, 10, 1 },
                    { 5, null, 11, 1 },
                    { 6, null, 14, 1 },
                    { 7, null, 15, 1 },
                    { 8, null, 16, 1 },
                    { 9, null, 17, 1 },
                    { 10, null, 18, 1 },
                    { 11, null, 20, 1 },
                    { 12, null, 23, 1 },
                    { 16, null, 10, 2 },
                    { 17, null, 11, 2 },
                    { 18, null, 14, 2 },
                    { 19, null, 15, 2 },
                    { 20, null, 16, 2 },
                    { 21, null, 17, 2 },
                    { 22, null, 18, 2 },
                    { 23, null, 20, 2 },
                    { 24, null, 23, 2 },
                    { 25, null, 2, 3 },
                    { 26, null, 4, 3 },
                    { 27, null, 7, 3 },
                    { 28, null, 9, 3 },
                    { 29, null, 13, 3 },
                    { 30, null, 22, 3 },
                    { 31, null, 19, 3 },
                    { 32, null, 2, 4 },
                    { 33, null, 4, 4 },
                    { 34, null, 7, 4 },
                    { 35, null, 9, 4 },
                    { 36, null, 12, 4 },
                    { 37, null, 21, 4 },
                    { 38, null, 19, 4 },
                    { 39, null, 24, 5 },
                    { 40, null, 25, 5 },
                    { 41, null, 5, 5 },
                    { 42, null, 8, 5 },
                    { 43, null, 12, 5 },
                    { 44, null, 21, 5 },
                    { 45, null, 19, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "endpointAccessNameRules",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "nameRules",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "nameRules",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "nameRules",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "endpointAccess",
                keyColumn: "id",
                keyValue: 7,
                column: "permission",
                value: "user.read.subordinate");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$PhJOxxRpBwnWJy9fc32tnw$vgnGvHyId5CNzFBxRBWMOsAGXIGofr1sWxoLzabwxCM");
        }
    }
}
