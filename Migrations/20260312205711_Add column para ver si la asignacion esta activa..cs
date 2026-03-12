﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class Addcolumnparaversilaasignacionestaactiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "user_assignments",
                type: "bit",
                nullable: false,
                defaultValue: true);


            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Md7htI5T4MstYssYBHk3sw$HWnz7XTNLjv8wn8GljlKCA8Cf4P9YinQ44MmocUHx1s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "user_assignments");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Sm+NKFz4fZcsgD8PKWl3qA$IrWL6E+1OvU91Lb7//rEVD8z1iIY5mZShJ9mhoaMxzA");
        }
    }
}
