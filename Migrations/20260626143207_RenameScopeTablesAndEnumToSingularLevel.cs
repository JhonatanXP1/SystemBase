using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class RenameScopeTablesAndEnumToSingularLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campusAreas_areas_idArea",
                table: "campusAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_campusAreas_campuses_idCampus",
                table: "campusAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_campuses_companies_idCompany",
                table: "campuses");

            migrationBuilder.DropTable(
                name: "campusAreaWorkShiftTeams");

            migrationBuilder.DropTable(
                name: "campusAreaWorkShifts");

            migrationBuilder.DropTable(
                name: "workShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teams",
                table: "teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_campuses",
                table: "campuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_campusAreas",
                table: "campusAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_areas",
                table: "areas");

            migrationBuilder.RenameTable(
                name: "teams",
                newName: "team");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "company");

            migrationBuilder.RenameTable(
                name: "campuses",
                newName: "campus");

            migrationBuilder.RenameTable(
                name: "campusAreas",
                newName: "campusArea");

            migrationBuilder.RenameTable(
                name: "areas",
                newName: "area");

            migrationBuilder.RenameIndex(
                name: "IX_campuses_idCompany",
                table: "campus",
                newName: "IX_campus_idCompany");

            migrationBuilder.RenameIndex(
                name: "IX_campusAreas_idCampus_idArea",
                table: "campusArea",
                newName: "IX_campusArea_idCampus_idArea");

            migrationBuilder.RenameIndex(
                name: "IX_campusAreas_idArea",
                table: "campusArea",
                newName: "IX_campusArea_idArea");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company",
                table: "company",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_campus",
                table: "campus",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_campusArea",
                table: "campusArea",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_area",
                table: "area",
                column: "id");

            migrationBuilder.CreateTable(
                name: "shift",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    hourInit = table.Column<TimeOnly>(type: "time", nullable: false),
                    hourEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campusAreaShift",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCampusArea = table.Column<int>(type: "int", nullable: false),
                    idShift = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campusAreaShift", x => x.id);
                    table.ForeignKey(
                        name: "FK_campusAreaShift_campusArea_idCampusArea",
                        column: x => x.idCampusArea,
                        principalTable: "campusArea",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_campusAreaShift_shift_idShift",
                        column: x => x.idShift,
                        principalTable: "shift",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "campusAreaShiftTeam",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCampusAreaShift = table.Column<int>(type: "int", nullable: false),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campusAreaShiftTeam", x => x.id);
                    table.ForeignKey(
                        name: "FK_campusAreaShiftTeam_campusAreaShift_idCampusAreaShift",
                        column: x => x.idCampusAreaShift,
                        principalTable: "campusAreaShift",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_campusAreaShiftTeam_team_idTeam",
                        column: x => x.idTeam,
                        principalTable: "team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "shift",
                columns: new[] { "id", "created", "hourEnd", "hourInit", "name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), new TimeOnly(14, 0, 0), new TimeOnly(6, 0, 0), "Mañana" },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), new TimeOnly(22, 0, 0), new TimeOnly(14, 0, 0), "Tarde" }
                });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 4,
                column: "scopeType",
                value: "area");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 5,
                column: "scopeType",
                value: "area");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 6,
                column: "scopeType",
                value: "area");


            migrationBuilder.InsertData(
                table: "campusAreaShift",
                columns: new[] { "id", "created", "idCampusArea", "idShift" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 1, 2 },
                    { 3, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 3, 1 },
                    { 4, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 3, 2 },
                    { 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "campusAreaShiftTeam",
                columns: new[] { "id", "created", "idCampusAreaShift", "idTeam" },
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

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaShift_idCampusArea_idShift",
                table: "campusAreaShift",
                columns: new[] { "idCampusArea", "idShift" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaShift_idShift",
                table: "campusAreaShift",
                column: "idShift");

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaShiftTeam_idCampusAreaShift_idTeam",
                table: "campusAreaShiftTeam",
                columns: new[] { "idCampusAreaShift", "idTeam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaShiftTeam_idTeam",
                table: "campusAreaShiftTeam",
                column: "idTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_campus_company_idCompany",
                table: "campus",
                column: "idCompany",
                principalTable: "company",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_campusArea_area_idArea",
                table: "campusArea",
                column: "idArea",
                principalTable: "area",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_campusArea_campus_idCampus",
                table: "campusArea",
                column: "idCampus",
                principalTable: "campus",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campus_company_idCompany",
                table: "campus");

            migrationBuilder.DropForeignKey(
                name: "FK_campusArea_area_idArea",
                table: "campusArea");

            migrationBuilder.DropForeignKey(
                name: "FK_campusArea_campus_idCampus",
                table: "campusArea");

            migrationBuilder.DropTable(
                name: "campusAreaShiftTeam");

            migrationBuilder.DropTable(
                name: "campusAreaShift");

            migrationBuilder.DropTable(
                name: "shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company",
                table: "company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_campusArea",
                table: "campusArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_campus",
                table: "campus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_area",
                table: "area");

            migrationBuilder.RenameTable(
                name: "team",
                newName: "teams");

            migrationBuilder.RenameTable(
                name: "company",
                newName: "companies");

            migrationBuilder.RenameTable(
                name: "campusArea",
                newName: "campusAreas");

            migrationBuilder.RenameTable(
                name: "campus",
                newName: "campuses");

            migrationBuilder.RenameTable(
                name: "area",
                newName: "areas");

            migrationBuilder.RenameIndex(
                name: "IX_campusArea_idCampus_idArea",
                table: "campusAreas",
                newName: "IX_campusAreas_idCampus_idArea");

            migrationBuilder.RenameIndex(
                name: "IX_campusArea_idArea",
                table: "campusAreas",
                newName: "IX_campusAreas_idArea");

            migrationBuilder.RenameIndex(
                name: "IX_campus_idCompany",
                table: "campuses",
                newName: "IX_campuses_idCompany");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teams",
                table: "teams",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_campusAreas",
                table: "campusAreas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_campuses",
                table: "campuses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_areas",
                table: "areas",
                column: "id");

            migrationBuilder.CreateTable(
                name: "workShifts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    hourEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    hourInit = table.Column<TimeOnly>(type: "time", nullable: false),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workShifts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campusAreaWorkShifts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCampusArea = table.Column<int>(type: "int", nullable: false),
                    idWorkShift = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campusAreaWorkShifts", x => x.id);
                    table.ForeignKey(
                        name: "FK_campusAreaWorkShifts_campusAreas_idCampusArea",
                        column: x => x.idCampusArea,
                        principalTable: "campusAreas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_campusAreaWorkShifts_workShifts_idWorkShift",
                        column: x => x.idWorkShift,
                        principalTable: "workShifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "campusAreaWorkShiftTeams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCampusAreaWorkShift = table.Column<int>(type: "int", nullable: false),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campusAreaWorkShiftTeams", x => x.id);
                    table.ForeignKey(
                        name: "FK_campusAreaWorkShiftTeams_campusAreaWorkShifts_idCampusAreaWorkShift",
                        column: x => x.idCampusAreaWorkShift,
                        principalTable: "campusAreaWorkShifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_campusAreaWorkShiftTeams_teams_idTeam",
                        column: x => x.idTeam,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 4,
                column: "scopeType",
                value: "campus_area");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 5,
                column: "scopeType",
                value: "campus_area");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 6,
                column: "scopeType",
                value: "campus_area");


            migrationBuilder.InsertData(
                table: "workShifts",
                columns: new[] { "id", "created", "hourEnd", "hourInit", "name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), new TimeOnly(14, 0, 0), new TimeOnly(6, 0, 0), "Mañana" },
                    { 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), new TimeOnly(22, 0, 0), new TimeOnly(14, 0, 0), "Tarde" }
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

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaWorkShifts_idCampusArea_idWorkShift",
                table: "campusAreaWorkShifts",
                columns: new[] { "idCampusArea", "idWorkShift" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaWorkShifts_idWorkShift",
                table: "campusAreaWorkShifts",
                column: "idWorkShift");

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaWorkShiftTeams_idCampusAreaWorkShift_idTeam",
                table: "campusAreaWorkShiftTeams",
                columns: new[] { "idCampusAreaWorkShift", "idTeam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_campusAreaWorkShiftTeams_idTeam",
                table: "campusAreaWorkShiftTeams",
                column: "idTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_campusAreas_areas_idArea",
                table: "campusAreas",
                column: "idArea",
                principalTable: "areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_campusAreas_campuses_idCampus",
                table: "campusAreas",
                column: "idCampus",
                principalTable: "campuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_campuses_companies_idCompany",
                table: "campuses",
                column: "idCompany",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
