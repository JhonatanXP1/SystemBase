using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrbita360Hierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "areas",
                columns: new[] { "id", "code", "created", "name" },
                values: new object[,]
                {
                    { 1, "PROD", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Producción" },
                    { 2, "RH", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Recursos Humanos" },
                    { 3, "ALM", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Almacén" },
                    { 4, "LIMP", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Limpieza" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "created", "direccion", "name" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Av. Independencia 200, Puebla, Pue.", "Órbita 360" });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "id", "created", "name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "PROD-A1" },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "PROD-A2" },
                    { 3, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "ALM-A1" },
                    { 4, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "ALM-A2" },
                    { 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "LIMP-A1" }
                });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 2,
                column: "scopeType",
                value: "campus");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 3,
                column: "scopeType",
                value: "campus");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "scopeId", "scopeType" },
                values: new object[] { 3, "campus_area" });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "scopeId", "scopeType" },
                values: new object[] { 4, "campus_area" });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 8,
                column: "scopeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 11,
                column: "scopeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 12,
                column: "scopeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 13,
                column: "scopeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 14,
                column: "scopeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 15,
                column: "scopeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 16,
                column: "scopeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 17,
                column: "scopeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 18,
                column: "scopeId",
                value: 7);

            migrationBuilder.InsertData(
                table: "userAssignments",
                columns: new[] { "id", "codeEmployee", "created", "deleteAt", "idRole", "idUser", "isActive", "scopeId", "scopeType" },
                values: new object[,]
                {
                    { 19, "COORD-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 7, true, 2, "team" },
                    { 20, "COORD-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 7, true, 3, "team" },
                    { 21, "COORD-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 8, true, 5, "team" },
                    { 22, "COORD-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 8, true, 6, "team" },
                    { 23, "COORD-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 8, true, 7, "team" }
                });


            migrationBuilder.InsertData(
                table: "workShifts",
                columns: new[] { "id", "created", "hourEnd", "hourInit", "name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), new TimeOnly(14, 0, 0), new TimeOnly(6, 0, 0), "Mañana" },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), new TimeOnly(22, 0, 0), new TimeOnly(14, 0, 0), "Tarde" }
                });

            migrationBuilder.InsertData(
                table: "campuses",
                columns: new[] { "id", "code", "created", "direccion", "idCompany", "name" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Carretera Puebla-Tlaxcala Km 5, Texmelucan, Pue.", 1, "Matriz Principal Puebla" });

            migrationBuilder.InsertData(
                table: "campusAreas",
                columns: new[] { "id", "created", "idArea", "idCampus" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 2, 1 },
                    { 3, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 3, 1 },
                    { 4, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "campusAreaWorkShifts",
                columns: new[] { "id", "created", "idCampusArea", "idWorkShift" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 2 },
                    { 3, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 3, 1 },
                    { 4, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 3, 2 },
                    { 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "campusAreaWorkShiftTeams",
                columns: new[] { "id", "created", "idCampusAreaWorkShift", "idTeam" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 2, 1 },
                    { 3, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 2 },
                    { 4, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 3, 3 },
                    { 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 4, 3 },
                    { 6, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 4, 4 },
                    { 7, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShiftTeams",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "campusAreas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "areas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShifts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShifts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShifts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShifts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "campusAreaWorkShifts",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "campusAreas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "campusAreas",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "campusAreas",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "workShifts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "workShifts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "areas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "areas",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "areas",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "campuses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 2,
                column: "scopeType",
                value: "campus_area");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 3,
                column: "scopeType",
                value: "campus_area");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "scopeId", "scopeType" },
                values: new object[] { 1, "campus_area_workdate" });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "scopeId", "scopeType" },
                values: new object[] { 2, "campus_area_workdate" });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 8,
                column: "scopeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 11,
                column: "scopeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 12,
                column: "scopeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 13,
                column: "scopeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 14,
                column: "scopeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 15,
                column: "scopeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 16,
                column: "scopeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 17,
                column: "scopeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 18,
                column: "scopeId",
                value: 2);

        }
    }
}
