using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationalScopeHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workShifts",
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
                    table.PrimaryKey("PK_workShifts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companyAreas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompany = table.Column<int>(type: "int", nullable: false),
                    idArea = table.Column<int>(type: "int", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyAreaWorkShiftTeams");

            migrationBuilder.DropTable(
                name: "companyAreaWorkShifts");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "companyAreas");

            migrationBuilder.DropTable(
                name: "workShifts");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "companies");

        }
    }
}
