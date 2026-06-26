using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersImageUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "/profile/loise.png", "$argon2id$v=19$m=32768,t=3,p=2$jFoauMd2iyzmYVYR1yQC8w$KMom+RiC97S1me2l5U5pZO7QXPLWpVeH53q+73zGbbc" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$M15qHjlWPTFjdgJYWzyZmg$0A23QPXTVCwpLyZA9L2gJQQzhQlHPfp4WdEiO9NsuSI");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$AaJAzWnR/ARKgCDsx4cUbA$PWHt/nBuwALS6wDluuRSp7tODe54iMbI5WkePZfotmg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "/profile/craig.png", "$argon2id$v=19$m=32768,t=3,p=2$irVbxPe3LVHpvkaWmTZOYg$r5XxgeJCGnzBdZtoiGwiocBaJG22spKKbfqyvduRQC0" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$d+mEkp8CSO+u3CU3ee/wWw$TIswvT+LV5NAtf1XmX9TokpY5Gd3dUcQqLy8UyQKt2Q");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "/profile/steve.png", "$argon2id$v=19$m=32768,t=3,p=2$hQLHjkb5/+2atRhTramqHQ$uP0CxGQZETrg33ryKGe83uF9IEtBfMw6StDJGZi+zf4" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "/profile/reese.png", "$argon2id$v=19$m=32768,t=3,p=2$gA9TEt+xSSCUD1Xmsub/PA$n3tF52M2pT4/GNFHBu0+zvZfv53DaOQXGJZfUBLbo9c" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$pYidoMRHGfHZ+3KdvG7yZg$N8zm2Y/sLaRYwsWVsySGCGa6qQM6XU80e1rMs+yVpGU");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$JGizOXk7Qh0QY+m42LhZbQ$Sr0P/Dlz4GihxeHJbpO+I8qjyYXain6CsqgnvnrbSeE");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$KXhY+6UIP7dpFSyXVRdZtA$JV8+JbE6F54KwT+2O2y9QRD0fWwahbRkQFaJqQnJ7Cs");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$GWrRaFaLxJmccVMYfQ7wUA$mgiNR02Z3Tl0ktarOSs2IfAZVfgF1S+hJY0j2gn/+V8");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$z9DxaKEgMicMtmqyaZ44vg$z3cjb0WN7ryRvUoLdlgpX2ut4NCPPvjji66eyGyKB3w");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$4e5VBKvaB7XMivJGGrAxGw$e9NyHp4eT+Le1IUPDyveOMI1B+JlMddS704BqxCEJzI");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$f6YGp70U1OU8RcuKwfBCFQ$JD/BhjhWguU7YmRq8BRFtSpH7ohtVcu1NdjQ1yATIzk");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$JPzg8Gi8jaA8SGjLhvg7jw$IW/ju7XHIjlZwYcZTsFpYoWqvqXkJEMbAQU0e775r8o");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$P5BXyIA7dNaM2RiHCo6UZA$Fzi30u1fOIJ1JwPv3ekbkjE4BT/LlSyL/7U9aP56Jrs");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "$argon2id$v=19$m=32768,t=3,p=2$mI+T/1JbTFrWc9HZyD5YtQ$5BmyEI61rPSBU2w0mQpZxW759A2kJb+uMLv8+Ln8Fl4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "imageUser", "password" },
                values: new object[] { "public/profile/loise.png", "$argon2id$v=19$m=32768,t=3,p=2$DMMimDTcoRQKlMt2IOMysw$qX4jf9JEn0UmkydOs/gJ2fOdoL2ht6D8zKcLxTgKaS8" });

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
    }
}
