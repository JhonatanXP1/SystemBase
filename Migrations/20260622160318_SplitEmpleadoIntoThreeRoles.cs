using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class SplitEmpleadoIntoThreeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Operador de producción");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "code", "created", "deleteAt", "idNameRule", "name" },
                values: new object[,]
                {
                    { 7, 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, "Auxiliar de almacén" },
                    { 8, 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, "Personal de limpieza industrial" }
                });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 10,
                column: "codeEmployee",
                value: "OP-01");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 11,
                column: "codeEmployee",
                value: "OP-02");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "ALM-01", 7 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "LIMP-01", 8 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 14,
                column: "codeEmployee",
                value: "OP-03");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "ALM-02", 7 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "ALM-03", 7 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "LIMP-02", 8 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "LIMP-03", 8 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$6PupBQtXPPf5uPYxZFRKCA$hhyq5bt0uF8rZhxuU+pQ7Q1mvq/svpqSv26FjyauvJI");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$JsVJEr2e3YKuCJoBaOFG6w$LvtxfKjXBMdJmFIOmV105FpD3GqUG9IfucllfZFjulk");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$QrzA4fPl+21XO6QQvVRotw$H1dzbIqwGpU5aGDsGEy0uEh2VnoN5aIxzX0jn2eJLH8");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$w+aZol6myU7n4EdigLFGkQ$dGqFf1mYksip8UpO1sGLsFxwhi9TQ0a6Uicp4uYq4KQ");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ROCZfUTPvmr1EmkW/Ul49w$r17mbQuRXhTxGBRhc3m/xErL04udpq4e5ex/ZNafylY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$n0f97mwyuojeacSWlu0edQ$iqh4xb0Otv3bROEVULrvmFBoSUTYCiBfeXHnisIvR7E");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$OBLDBrsyE/57BsVoXhHGdQ$Ler9hiSiYlKewzS7oacngmY++HqL6zcUI9GFoX15L40");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Ws9sFbD46G0BzoPvDMb0+g$jZwUD3iS4QT/FLkatxxc9TMFrFXrnuKfjCUd+xpRi7Y");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$UUSnyE1Vd2H520WePPaLmA$Hh2c4ynJxM2OfWxz4oCc3i/jIQ/B8Uwp4NTD0MxpAk0");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$3aaGWlfBTxTb/NJa3K2Tvg$R3Q7QpdNyRT/qNr6u+FSe9VEFeV4M6KAYL+2eqsztkw");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$fKNVLO8+V4Q9JMsp09GThQ$Kcwx3j7csAk5u7cjCWMUy2C4EXlCxoYo9erp5lk8TkQ");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$itoEHjbosznXfKUuSz/XsQ$6S5if0Gp19wO4Xl66mCOewDuwEr/am+j3vfrzNSTN7M");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$v0mmugB10Ug30bah5hNOHQ$EVjEnseprGFhyobaZrtOeZrK3Rl3tU6zGuFQFeB4CDc");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ukAzddvsnoK/dFkySj+Rpw$fbdeO6YfMyHiORyRoPUrQzy4DPBsPBY5mEFtLt+V1FY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$c+jaTjJjR4BKGR9N3ZJjIA$IQofiE5s+Fa+sLSAUN48cAsdJkFr8Pl4/kor+9kzRg8");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$IYP5Op3Bq3CW2njD2XBTqg$8MxaeLhWwlvoBwsYl/JutUbZn/ROu3kyGLLfRMeIpXU");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$zUkXZzpgH/T8ocEsK2lnNA$LXMi4YPlJbvRoWb2qLk+PmquPAGP5AAbzoRGhvTtV6o");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Empleado");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 10,
                column: "codeEmployee",
                value: "EMP-02");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 11,
                column: "codeEmployee",
                value: "EMP-03");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "EMP-04", 6 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "EMP-05", 6 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 14,
                column: "codeEmployee",
                value: "EMP-06");

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "EMP-07", 6 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "EMP-08", 6 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "EMP-09", 6 });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "codeEmployee", "idRole" },
                values: new object[] { "EMP-10", 6 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$z1WZ4olhnFndxjA7LTQ7Nw$F95pZSsJdPVKNMrE3PAg5RzlqOQkzZZRPt6BbGCwdTc");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$4tKB16eykxZFSLX7X42doQ$RKBVmfVNEGU7gKIO8WOp/JGKncmcrNxxL0UhtFCz3yw");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$lqelEUs47hZPGkYib6p/mA$azJZtzH4858TqvM8pNG6bhITgH+u0a9XFcCNImoB26g");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$HkAwnaVlXokxToowzQrkjA$C02VeBBuEdB5MP8UdbvnRcdZRmHPoRxYNsFXeSr7nyA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$loOemiZkYCoXDa3RbU1+1A$NThIhzSD9oYGMTkwlFQ1+iv6tW/x/1Fa2r36ponesuY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$blyxXCrJPwyRhM8cdiV64Q$DXWvUBeV0F+gV9l8fjxXzbtgsf9zXENtQ0lEhL00TtY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$76idAPH7NkDsLbwnx3oY/g$VIW1tyUB9AX3XE3HCV83XgMxatzR1PphDSfvCGKTqBA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$rlMb0vsWl6/xwesHVINiiw$VKf8NNaLh855wGaqNgq4Vd71xa9wJJ8Wc+Ewg7L4frw");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$9a9y1EFSrNt55c5ZygRmVg$XMdYgeOWylBv072+86zRuK2dyThyydJGclf33IJPr5w");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$I/GL6lC8lpiIh/ngqBdJXQ$6C0rw+9Ll7ebMwBfkpWklZNgoozo8MWBqbQqI+oElco");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$9ZDfSQsKFCB2o8t7b3kqbQ$2uULfaGr/E7vMhrJoAA+2d08zYYz/Ssg7nbSL4HdoEg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$1RBZo0CeJKCVCgjbQCgJsw$sz6Avgerx7w6ExuHxcUjEMX5qTZVHZreOXd9weaRa3A");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$CXDqql1CyY684awG+WYngg$9/TLsBiSkTgj4bsQm5UpsuHkswSYQz2sQFU5S6A8PxI");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$wZIW2B2oFabiplctSQPC+Q$KY3neq71wOWAUO6+pLpO5RHTB8tuFNeKhH5etB1gEwQ");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$JBwRirhjVTlKCNa3sQLT2w$x3csI9IiBqzcQFPf+U0Ans9t7KlnLmkVla51sxAz1NM");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$mdDJ+zRt+0oRp8fnt59PCw$GNnr6dO+T/i4kHuOXopMfun4GGknzSVzSdkDA+oR+GY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$88PSfSImnEJpbcEFV/M/Lg$a81Shqp3ayN3pTbp9Q9On1zs6nHQsiwfBpWe08u24c8");
        }
    }
}
