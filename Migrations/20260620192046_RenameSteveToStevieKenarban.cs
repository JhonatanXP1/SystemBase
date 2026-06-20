using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class RenameSteveToStevieKenarban : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 9);

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
                columns: new[] { "app", "name", "password", "userName" },
                values: new object[] { "Kenarban", "Stevie", "$argon2id$v=19$m=32768,t=3,p=2$blyxXCrJPwyRhM8cdiV64Q$DXWvUBeV0F+gV9l8fjxXzbtgsf9zXENtQ0lEhL00TtY", "@stevie" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$6+0AbFwMWLFAImk0LT8Pow$4wDRjLQM4GwQVQTHGbFji12kp0Jb4Vh8wrIXNMiqZf8");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Yf07t1o7B9ziosJXSjCDCg$5YC99QAAx/2AMxsCwc7SiT4rViMG/OaHGRx8ZRUAI24");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$EscPM9IUfIp07zPJS+jiSQ$UdDFPWp0ywpDsw05/o8Nb8qnOjQPB8PgAQSEGafsV8U");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$nPd6hWeC7eXGZwk9Wacb0w$XnQ3FM8Z0RD2hDYR5VdPtluvUR8AkVqzFC7edjBq1rA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$VHwB5YkoyKty0dBSjoMtug$J3avcTs1jle05hn0uPnlfOZVyv1qmrb8NRiPXtKdgSU");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "app", "name", "password", "userName" },
                values: new object[] { "Feldspar", "Steve", "$argon2id$v=19$m=32768,t=3,p=2$vyaYxZWvO1/lSHNDn/YUVw$msvPXq31tFC7m8FnT7HPxqfekaX/shkfEO3GyJs7ixU", "@steve" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$EdEC+kkpXJ0ySwzPcQ+9XA$zs0UZ7iGhy9qlj/maNZwK36Ft6XKZiJ8NQggqgI3MKo");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$niLWAkDR7z+mhQXWtC4JrQ$u9DxuqQEqZuTxdQ6vQxxGNKKpR/tMfE3arZ/71yw4Kk");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$TOgTMZfzEJIiNYypZfMA0w$9UljxxUiS4TQZ409Hv25k++EdyOBZVRcMpd6dQ7hSL4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$lJfWGpwCnYFn68BAZvfr9Q$n1cGeTLdEH7Gz1ykSetVMb5/wavZbQwoVzP1fKif3Xg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$nM0wgv8xceWcz+MSEvXKkw$aLmfT5Rl4WY8bpH/x9vNkN+glUPwNBmmmZ1t0TVBwl0");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$3qN9p1BTL7yNCjbOdypjig$Ils7V/Lyne16TD67dcEzlHbBVKL6t/iwuG2vFj3kGZo");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$P4j+6N3aUiY1p0NpB+DHhg$T/bU7YlDYgGwzOZha/RIhsnv1DOkDsaPTAKPKEqnRAI");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$5A43Ou+jzYq4CzEmR767UQ$w8b1lrt5SOTZlP+l53vl7lP5Og8ApDKCFDnkzCHtZOc");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$bv/0es8Rf3RvnnpizYziLw$3/pZCgpN1qr2+OrjOMZ5QQPA7BXKO944kGEzg2WtUEo");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$4M0swX1/HMc8hJeg9OnGlw$hWObyArcQcnvCMsG162DhUUFiegS9ARtqLpasge4mEA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$YDa+BjtkMR2gMtt3cekoow$Q6m4dkh9evsUBVb+NKW/mA89afoIdB6L/SJZJlx7u5U");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "apm", "app", "created", "deleteAt", "imageUser", "name", "password", "userName" },
                values: new object[] { 9, null, "Kenarban", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Stevie", "$argon2id$v=19$m=32768,t=3,p=2$em1wCfIK65xnCD6ZmttDCw$CNdyaHt2PEXa+Zp/PFjq+/9TWXwc7RIcwZ4ZNIHJY6s", "@stevie" });

            migrationBuilder.InsertData(
                table: "userAssignments",
                columns: new[] { "id", "codeEmployee", "created", "deleteAt", "idRole", "idUser", "isActive", "scopeId", "scopeType" },
                values: new object[] { 9, "EMP-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 9, true, 1, "team" });
        }
    }
}
