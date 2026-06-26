using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersImageUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "imageUser", "password", "userName" },
                values: new object[] { "public/profile/loise.png", "$argon2id$v=19$m=32768,t=3,p=2$DMMimDTcoRQKlMt2IOMysw$qX4jf9JEn0UmkydOs/gJ2fOdoL2ht6D8zKcLxTgKaS8", "lois@orbita360.com" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$gso16jLwIbFZHY8BzHE0Eg$07WJYlZv8hsVbbQMYLnMbXF2s8AjOMmO0bTGOKOTumU");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$tkSK9sZ4rUgyeyceijBsjA$jF348Yi59RFtBElAsVrmTU3GDtdGMARtFk/mCKJk3lw");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "public/profile/craig.png", "$argon2id$v=19$m=32768,t=3,p=2$0DYxUcmLavd9SZyg5neqnA$gV/6372lI2RxZYYwGbFMLPyCp8pW1t+fTY+ymgJcjJI" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$lTXCi7zosJzIl+U7ObnFaw$XT0zqskbb8gGW3S70cpK/344hMjfkM9wHTJzQACdbBY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "public/profile/steve.png", "$argon2id$v=19$m=32768,t=3,p=2$BCSP9qaHIsjsU6gPcsD0JQ$VDI+pirc3dP7oDLv5sElLQH1WCVGWZS237g8Q/ZoXxg" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "public/profile/reese.png", "$argon2id$v=19$m=32768,t=3,p=2$uR/A5nJOCDuq1WTxYk1BdA$7ypwQLCxYFQ/f+gNNYg0C0toa8zuTRBFPaCuHujWXeU" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$D1d73drOyhSC5MZcjvtmhw$FnBXAMHNYKVTx/CU0WD/aufn97id3wnEhLGeRgRXx0I");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Y9da1VZ18mHl6E0NTEfcGw$5usZYj1pOeg4F+0ZnKLmEy9bvSZwNEayZyKNH3dAWD8");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$Q2YUgT6/sw4LMudA7bG+nQ$WchVC3qUUBCM/M8m91AAxXt94fAgwKClkTLEkQwAjOg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$+IHs5pv0/34QlORMjzmcWw$7I43XGzaca/1MtXBajUIXjeTIcC+FCZHORBwEQPy/6w");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ooXgWlay2Jx5T8tpieS23w$hF1gT3WlVg498dWsz7rJkKGjDNllsK6+LzyaFBkk3R4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$x56f0zYsYXuJnG5EmowjOA$7y60fBCtCaDNgZ68Y64pRI5pjlJxDjloY7c6kLUdBX0");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$t/4L5HdPTQfzn1rj0Psy3w$RzjwC8C9gESpRw3fA4SrLc3CyHiy3TY66m1MCki3HPE");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$wgYn0sID4t593T2/QwlYPw$8vphF+FkEKMur2AW88YCUYVdaYI667nyb7TOXGucIzA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$IA8qZ4EK70m7u4Oe+ftGHw$8aIL01HAdFOMSRiiA3bGCn6W8Uhu9p4JDiJh6G4AVJs");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$OqnaLUJPhFJBpuOYBO5uKw$4B6CFc6LfBzefjkrz1DwsrxepZstGpPzMZdQ863yJQQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "imageUser", "password", "userName" },
                values: new object[] { null, "$argon2id$v=19$m=32768,t=3,p=2$DxHYmpTWCY53vP1wjM6xXg$92QyVAiLlzqGvRFqHBZk4tPGLswBUVjiGazqcz98ags", "@lois" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$z8TWw1B8cJbEERUC/K3M5A$MMPvYB7o07E4YzekySuT874BYxlWoA+CMHiA7MVsDDk");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$FS8hC1aJ5RIAuoAkXdU0bA$F9e550P3mutYxn6HNrsk3KxpzOmxjETyEfD0Wx/In/I");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "imageUser", "password" },
                values: new object[] { null, "$argon2id$v=19$m=32768,t=3,p=2$0oSuv31+d5cPErtwiwbVYQ$PxV42UGi6eB5qgRSya+0hQDcCcOKsrFzDRkUo5/gd4A" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$P1BXnEA7Ptyn828ectzNuQ$ecKMrQyiGQTzzLvrWuRnGQnBiRdlA2gQ/uiKC/4lArs");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "imageUser", "password" },
                values: new object[] { null, "$argon2id$v=19$m=32768,t=3,p=2$naihnc2yBD8La3TQQ74BSQ$uZjfTFDQ8CqPudHu1cNSgWXti+W6cDEu9W3YKXrLGRM" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "imageUser", "password" },
                values: new object[] { null, "$argon2id$v=19$m=32768,t=3,p=2$AJ7eUyxe2obEI3BV+X9vug$7vVVFjDNUUlabOr+E4tC1atCcJ3GdGVIV8EwLAgKQqA" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$GWPTO/qXLsBIkmbpJZ3EOg$CJEiO0J/6COuZP7rpnGHfQRvcsHC5YVm4VEpAJqEDBs");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$ecmOymj7kfVuM4mZmMS1wg$WVuIs8Buh7l+4VMka4iFimr+oKy7TT58TP5aSEK9toA");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$xmg20Ecjp/fqDL467g/bkQ$X9+Q+htgLzDsQ14w/vnBW4KJNCoMB2Yx5NgbJae0UKo");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$QcR3YMnoOMWr1yCmPlrZrQ$CVGgNr+dPNibfxVJS62S2DlNFWZ3/3pfmYKbgQ3Zm7k");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$kGhlers5G7+JolUujtHgGQ$IxvovdPzrVqlZAeIcIwgOJ2/HOcIPrGNxPLwUGHm9Bo");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$rioyZzkveIP6zQoWC8D1nQ$gqlJm0aqvCsCEh6YWRd/H7v1B2Hl9OBQD1lmOswjlMk");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$5XPs6uIjle2QHm/geZ6/Jg$3GWngPaXfWgCMg8/4omef5Iv13HkUT14wkDJUm6Nk7A");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$acl4M4xVl7MX3cj5Gb4irg$+0gGCK3Yyk5e5OjLm1O8CM3w21QwHmWiz0H/xRyYzNY");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$yS+gZMunkFZt7fFQub2OLA$fZKSa7HmR3mydTYeP0tv2uyuLIa2JXK0g2Qo2hakQJg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$TrmU/Frc4aHKFZMJc8chvg$Ed/x+s/s7Guj4hbhZeKRnWZ5xf4pLGu91tFim6qLu6Y");
        }
    }
}
