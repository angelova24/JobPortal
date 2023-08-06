using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class SeedEmployerAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"), 0, "b505e069-699a-4516-95d8-d1e529a5d5be", "employer@test.com", false, "Employer", "User", false, null, "employer@test.com", "employer@test.com", "AQAAAAEAACcQAAAAEHyGOeLIaPR4Bi1r8650lmlU++xqLOdWEYbaJdCZmv98ZbZ1igiZ0TYgR27J/wCVhQ==", null, false, "49380414-9ca7-4166-ad7a-5fd3afc11bd2", false, "employer@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"), 0, "778d07e6-6aca-4554-9d00-1da293a343d5", "admin@test.com", false, "Admin", "User", false, null, "admin@test.com", "admin@test.com", "AQAAAAEAACcQAAAAEBChgAZP5JmR+9m3XrFdrEsg6KScevXZLU4Z9X+XtY7EIVQXQMQFSoeNpc+xTzvx9Q==", null, false, "1ef229b1-4bfd-44eb-a12a-527a0df93d3d", false, "admin@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"));
        }
    }
}
