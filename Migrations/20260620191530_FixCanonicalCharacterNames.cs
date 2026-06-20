using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class FixCanonicalCharacterNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$vyaYxZWvO1/lSHNDn/YUVw$msvPXq31tFC7m8FnT7HPxqfekaX/shkfEO3GyJs7ixU");

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
                keyValue: 9,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$em1wCfIK65xnCD6ZmttDCw$CNdyaHt2PEXa+Zp/PFjq+/9TWXwc7RIcwZ4ZNIHJY6s");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "app", "password" },
                values: new object[] { null, "$argon2id$v=19$m=32768,t=3,p=2$TOgTMZfzEJIiNYypZfMA0w$9UljxxUiS4TQZ409Hv25k++EdyOBZVRcMpd6dQ7hSL4" });

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
                columns: new[] { "name", "password", "userName" },
                values: new object[] { "Davey", "$argon2id$v=19$m=32768,t=3,p=2$bv/0es8Rf3RvnnpizYziLw$3/pZCgpN1qr2+OrjOMZ5QQPA7BXKO944kGEzg2WtUEo", "@davey" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "password", "userName" },
                values: new object[] { "Zoe", "$argon2id$v=19$m=32768,t=3,p=2$4M0swX1/HMc8hJeg9OnGlw$hWObyArcQcnvCMsG162DhUUFiegS9ARtqLpasge4mEA", "@zoe" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "password", "userName" },
                values: new object[] { "Penelope", "$argon2id$v=19$m=32768,t=3,p=2$YDa+BjtkMR2gMtt3cekoow$Q6m4dkh9evsUBVb+NKW/mA89afoIdB6L/SJZJlx7u5U", "@penelope" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$sO0bnRooK7aeDHn8MstykA$xeam0eUN5LguhZDn3oUv8PAvYkf4SFdYA4Wo5O4ciFc");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ShFn/MrkfIichTqnHwn/GA$kToaPC/Lhu9+6JazwOVovk5MXU3KcObrBmU2+p3YPPM");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$kgW2lDa3s+WnbCQCLpK3Mw$H/tjYJ6ivxmzJoiqwyTAtTUdZYRn84ed/uHS8/kh9Jw");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$SYlM3Lqt7i9Sf4snf5MPSA$EiB7DPWN0Xf/SMf/HQsWmJX29NDzYcutX1oQly2dMr0");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$lTOhKUuJUwn4NLV+Sr9C9w$oNIkeCp+VYroz3rfkX+iUDJz2EtMUzc6oVWLR39FFrM");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$khIjhVdGgtgRJUwu2vDCqw$0wtXhKR8P+D3T0aPKk1VhjY7Rs45kSfodX/eMVHFR7M");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$AxB7fKOgwd14ZUZ/+JHZkQ$ZKcoiEOvDUVazQx+s6zzOwuVudepXi51xPZlSFFb1IA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Lf+1/c/g+IZsgfUXleG9Dg$E0LS4dOcdrKq53UyWdv+qFgAnXcmIMXdxHyBg0x3+yg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$O/B1d9cqkzPk3qqldZe9Xg$FcFY+X9DQMTTIYF/FaOX31gFSXd1irCJGdyiJFjVYAU");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "app", "password" },
                values: new object[] { "Hooper", "$argon2id$v=19$m=32768,t=3,p=2$Mt7HU4FLeZwzffk1rsa8Jg$G6pIYimuWzcBHYIiH/7Dbd/WeWd0MkFgitVGj7Rij6M" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$nKy+oSp/WO2kv/CDLqX6RA$2ptO7sCmGSP0fnh6Y6XGuq6ewoJSWJFt0sDHomITenY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$QifJyMhW5qn2g1zwo2On1Q$LGVEkQY/hSPb4UQwo5jFhxLl8xxyMYmvmgKbEYmjH5o");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Q0pYMdXd1ltQyh6R0lRd/A$zyO4BBxoBqjAfiut5SdJT3OfFaXIBdDCD4/M3CyYeyg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$2Hb3+ZG1AbHUOLGYKeLTVg$DLU+et1WVjmTrnjkf2YXsQuuV6weEyBztjB5Uxsfw4k");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$QI/XRxFCd9Vfa4K9VBi2iw$HXczuWUV65V7X1b/gxYDIksCpNaWCiUbxaagpEq50dI");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "password", "userName" },
                values: new object[] { "Special Kid 1", "$argon2id$v=19$m=32768,t=3,p=2$hBaIlnwOj+M2FaEz4l3T8w$qN4hhlfiYdEsi4oPhQAis+dRRrVfU2yhLJsJ4J7LjAM", "@specialkid1" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "password", "userName" },
                values: new object[] { "Special Kid 2", "$argon2id$v=19$m=32768,t=3,p=2$G7vLhXAl+Jy4xAjg/aQLtw$792XMVi5GTUvTPT1HucdMDiHw1sCJ6PQkN/qN9gvApg", "@specialkid2" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "password", "userName" },
                values: new object[] { "Special Kid 3", "$argon2id$v=19$m=32768,t=3,p=2$FGrouedYbYb2f30TRKlwmA$TGacnEWzAVLatgf3ZnFOlaR8FLlhutZDCJFD99D/umY", "@specialkid3" });
        }
    }
}
