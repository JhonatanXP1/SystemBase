using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class AddCampusLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyAreaWorkShiftTeams");

            migrationBuilder.DropTable(
                name: "companyAreaWorkShifts");

            migrationBuilder.DropTable(
                name: "companyAreas");

            migrationBuilder.CreateTable(
                name: "campuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompany = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campuses", x => x.id);
                    table.ForeignKey(
                        name: "FK_campuses_companies_idCompany",
                        column: x => x.idCompany,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "campusAreas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCampus = table.Column<int>(type: "int", nullable: false),
                    idArea = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campusAreas", x => x.id);
                    table.ForeignKey(
                        name: "FK_campusAreas_areas_idArea",
                        column: x => x.idArea,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_campusAreas_campuses_idCampus",
                        column: x => x.idCampus,
                        principalTable: "campuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_campusAreas_idArea",
                table: "campusAreas",
                column: "idArea");

            migrationBuilder.CreateIndex(
                name: "IX_campusAreas_idCampus_idArea",
                table: "campusAreas",
                columns: new[] { "idCampus", "idArea" },
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_campuses_idCompany",
                table: "campuses",
                column: "idCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campusAreaWorkShiftTeams");

            migrationBuilder.DropTable(
                name: "campusAreaWorkShifts");

            migrationBuilder.DropTable(
                name: "campusAreas");

            migrationBuilder.DropTable(
                name: "campuses");

            migrationBuilder.CreateTable(
                name: "companyAreas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idArea = table.Column<int>(type: "int", nullable: false),
                    idCompany = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyAreas", x => x.id);
                    table.ForeignKey(
                        name: "FK_companyAreas_areas_idArea",
                        column: x => x.idArea,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_companyAreas_companies_idCompany",
                        column: x => x.idCompany,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "companyAreaWorkShifts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompanyArea = table.Column<int>(type: "int", nullable: false),
                    idWorkShift = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyAreaWorkShifts", x => x.id);
                    table.ForeignKey(
                        name: "FK_companyAreaWorkShifts_companyAreas_idCompanyArea",
                        column: x => x.idCompanyArea,
                        principalTable: "companyAreas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_companyAreaWorkShifts_workShifts_idWorkShift",
                        column: x => x.idWorkShift,
                        principalTable: "workShifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "companyAreaWorkShiftTeams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompanyAreaWorkShift = table.Column<int>(type: "int", nullable: false),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyAreaWorkShiftTeams", x => x.id);
                    table.ForeignKey(
                        name: "FK_companyAreaWorkShiftTeams_companyAreaWorkShifts_idCompanyAreaWorkShift",
                        column: x => x.idCompanyAreaWorkShift,
                        principalTable: "companyAreaWorkShifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_companyAreaWorkShiftTeams_teams_idTeam",
                        column: x => x.idTeam,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companyAreas_idArea",
                table: "companyAreas",
                column: "idArea");

            migrationBuilder.CreateIndex(
                name: "IX_companyAreas_idCompany_idArea",
                table: "companyAreas",
                columns: new[] { "idCompany", "idArea" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyAreaWorkShifts_idCompanyArea_idWorkShift",
                table: "companyAreaWorkShifts",
                columns: new[] { "idCompanyArea", "idWorkShift" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyAreaWorkShifts_idWorkShift",
                table: "companyAreaWorkShifts",
                column: "idWorkShift");

            migrationBuilder.CreateIndex(
                name: "IX_companyAreaWorkShiftTeams_idCompanyAreaWorkShift_idTeam",
                table: "companyAreaWorkShiftTeams",
                columns: new[] { "idCompanyAreaWorkShift", "idTeam" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyAreaWorkShiftTeams_idTeam",
                table: "companyAreaWorkShiftTeams",
                column: "idTeam");
        }
    }
}
