using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemBase.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceBaseSeedWithEmpresa1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "code", "created", "deleteAt", "idNameRule", "name" },
                values: new object[,]
                {
                    { 3, 2, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 2, "Gerente RH" },
                    { 4, 3, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 3, "Supervisor" },
                    { 5, 4, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 4, "Coordinador" },
                    { 6, 5, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, "Empleado" }
                });

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "codeEmployee", "scopeId" },
                values: new object[] { "CEO-01", 1 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "apm", "app", "name", "password", "userName" },
                values: new object[] { null, null, "Lois", "$argon2id$v=19$m=32768,t=3,p=2$sO0bnRooK7aeDHn8MstykA$xeam0eUN5LguhZDn3oUv8PAvYkf4SFdYA4Wo5O4ciFc", "@lois" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "apm", "app", "created", "deleteAt", "imageUser", "name", "password", "userName" },
                values: new object[,]
                {
                    { 2, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Hal", "$argon2id$v=19$m=32768,t=3,p=2$ShFn/MrkfIichTqnHwn/GA$kToaPC/Lhu9+6JazwOVovk5MXU3KcObrBmU2+p3YPPM", "@hal" },
                    { 3, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Francis", "$argon2id$v=19$m=32768,t=3,p=2$kgW2lDa3s+WnbCQCLpK3Mw$H/tjYJ6ivxmzJoiqwyTAtTUdZYRn84ed/uHS8/kh9Jw", "@francis" },
                    { 4, null, "Feldspar", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Craig", "$argon2id$v=19$m=32768,t=3,p=2$SYlM3Lqt7i9Sf4snf5MPSA$EiB7DPWN0Xf/SMf/HQsWmJX29NDzYcutX1oQly2dMr0", "@craig" },
                    { 5, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Malcolm", "$argon2id$v=19$m=32768,t=3,p=2$lTOhKUuJUwn4NLV+Sr9C9w$oNIkeCp+VYroz3rfkX+iUDJz2EtMUzc6oVWLR39FFrM", "@malcolm" },
                    { 6, null, "Feldspar", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Steve", "$argon2id$v=19$m=32768,t=3,p=2$khIjhVdGgtgRJUwu2vDCqw$0wtXhKR8P+D3T0aPKk1VhjY7Rs45kSfodX/eMVHFR7M", "@steve" },
                    { 7, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Reese", "$argon2id$v=19$m=32768,t=3,p=2$AxB7fKOgwd14ZUZ/+JHZkQ$ZKcoiEOvDUVazQx+s6zzOwuVudepXi51xPZlSFFb1IA", "@reese" },
                    { 8, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Dewey", "$argon2id$v=19$m=32768,t=3,p=2$Lf+1/c/g+IZsgfUXleG9Dg$E0LS4dOcdrKq53UyWdv+qFgAnXcmIMXdxHyBg0x3+yg", "@dewey" },
                    { 9, null, "Kenarban", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Stevie", "$argon2id$v=19$m=32768,t=3,p=2$O/B1d9cqkzPk3qqldZe9Xg$FcFY+X9DQMTTIYF/FaOX31gFSXd1irCJGdyiJFjVYAU", "@stevie" },
                    { 10, null, "Hooper", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Lloyd", "$argon2id$v=19$m=32768,t=3,p=2$Mt7HU4FLeZwzffk1rsa8Jg$G6pIYimuWzcBHYIiH/7Dbd/WeWd0MkFgitVGj7Rij6M", "@lloyd" },
                    { 11, null, "Hooper", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Dabney", "$argon2id$v=19$m=32768,t=3,p=2$nKy+oSp/WO2kv/CDLqX6RA$2ptO7sCmGSP0fnh6Y6XGuq6ewoJSWJFt0sDHomITenY", "@dabney" },
                    { 12, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Kevin", "$argon2id$v=19$m=32768,t=3,p=2$QifJyMhW5qn2g1zwo2On1Q$LGVEkQY/hSPb4UQwo5jFhxLl8xxyMYmvmgKbEYmjH5o", "@kevin" },
                    { 13, null, "Sanders", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Cynthia", "$argon2id$v=19$m=32768,t=3,p=2$Q0pYMdXd1ltQyh6R0lRd/A$zyO4BBxoBqjAfiut5SdJT3OfFaXIBdDCD4/M3CyYeyg", "@cynthia" },
                    { 14, null, "Hanson", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "David", "$argon2id$v=19$m=32768,t=3,p=2$2Hb3+ZG1AbHUOLGYKeLTVg$DLU+et1WVjmTrnjkf2YXsQuuV6weEyBztjB5Uxsfw4k", "@davidh" },
                    { 15, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Chad", "$argon2id$v=19$m=32768,t=3,p=2$QI/XRxFCd9Vfa4K9VBi2iw$HXczuWUV65V7X1b/gxYDIksCpNaWCiUbxaagpEq50dI", "@chad" },
                    { 16, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Special Kid 1", "$argon2id$v=19$m=32768,t=3,p=2$hBaIlnwOj+M2FaEz4l3T8w$qN4hhlfiYdEsi4oPhQAis+dRRrVfU2yhLJsJ4J7LjAM", "@specialkid1" },
                    { 17, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Special Kid 2", "$argon2id$v=19$m=32768,t=3,p=2$G7vLhXAl+Jy4xAjg/aQLtw$792XMVi5GTUvTPT1HucdMDiHw1sCJ6PQkN/qN9gvApg", "@specialkid2" },
                    { 18, null, null, new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, null, "Special Kid 3", "$argon2id$v=19$m=32768,t=3,p=2$FGrouedYbYb2f30TRKlwmA$TGacnEWzAVLatgf3ZnFOlaR8FLlhutZDCJFD99D/umY", "@specialkid3" }
                });

            migrationBuilder.InsertData(
                table: "userAssignments",
                columns: new[] { "id", "codeEmployee", "created", "deleteAt", "idRole", "idUser", "isActive", "scopeId", "scopeType" },
                values: new object[,]
                {
                    { 2, "GG-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 2, 2, true, 1, "company_area" },
                    { 3, "GG-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 2, 3, true, 1, "company_area" },
                    { 4, "GRH-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 3, 4, true, 2, "company_area" },
                    { 5, "SUP-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 4, 5, true, 1, "company_area_workdate" },
                    { 6, "SUP-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 4, 6, true, 2, "company_area_workdate" },
                    { 7, "COORD-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 7, true, 1, "team" },
                    { 8, "COORD-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 5, 8, true, 2, "team" },
                    { 9, "EMP-01", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 9, true, 1, "team" },
                    { 10, "EMP-02", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 10, true, 1, "team" },
                    { 11, "EMP-03", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 11, true, 1, "team" },
                    { 12, "EMP-04", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 12, true, 1, "team" },
                    { 13, "EMP-05", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 13, true, 1, "team" },
                    { 14, "EMP-06", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 14, true, 2, "team" },
                    { 15, "EMP-07", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 15, true, 2, "team" },
                    { 16, "EMP-08", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 16, true, 2, "team" },
                    { 17, "EMP-09", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 17, true, 2, "team" },
                    { 18, "EMP-10", new DateTimeOffset(new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, 6, 18, true, 2, "team" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "userAssignments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "codeEmployee", "scopeId" },
                values: new object[] { "N1-12", null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "apm", "app", "name", "password", "userName" },
                values: new object[] { "Mendez", "Diaz", "Jhonatan", "$argon2id$v=19$m=32768,t=3,p=2$4Dz7niopJiq3dWHvKNFNpw$nBw17x935TrghYRZde4si8EdbVBePQKUI2hu6TFgPM8", "@adminDev" });
        }
    }
}
