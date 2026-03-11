using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class Asignarunrolealusuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ZnUskIpbF1AMN0PqB1eWAg$wDgDdbCTZdJP5QHiTEn/Y5cjkvb2jRKnZYKBqoe2Dfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$CTSileQZE8aFOpkqzdI2IA$n1LOdL1Rgbnvf7+qNUiaE2Nr1n0EXOckqZsyNJCCk+I");
        }
    }
}
