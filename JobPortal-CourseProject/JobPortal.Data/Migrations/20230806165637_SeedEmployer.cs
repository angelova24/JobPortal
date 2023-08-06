using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class SeedEmployer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f9bcd45-6004-45b4-b766-5b17cfa0503a", "AQAAAAEAACcQAAAAECnoA/RFXDapzLyjERbjuOZlqJjoYa8aTfNw+V/7ivNe2+ge3UeNWPuYouVjvMcVqg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6c87784-e4c8-4242-bdd3-92e73b4dfb29", "AQAAAAEAACcQAAAAELmbXECuN569PKUlwUDUowZFxfYjBYixrP+KzxXSeXNAiZ4M5Gb/yvemeP2B0c1lCg==" });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "CompanyAddress", "CompanyName", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Sofia", "Awesome Company", "+359888888888", new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b505e069-699a-4516-95d8-d1e529a5d5be", "AQAAAAEAACcQAAAAEHyGOeLIaPR4Bi1r8650lmlU++xqLOdWEYbaJdCZmv98ZbZ1igiZ0TYgR27J/wCVhQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "778d07e6-6aca-4554-9d00-1da293a343d5", "AQAAAAEAACcQAAAAEBChgAZP5JmR+9m3XrFdrEsg6KScevXZLU4Z9X+XtY7EIVQXQMQFSoeNpc+xTzvx9Q==" });
        }
    }
}
