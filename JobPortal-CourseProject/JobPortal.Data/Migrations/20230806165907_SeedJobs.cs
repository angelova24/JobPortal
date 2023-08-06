using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class SeedJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87690d3d-97d1-48b5-9a27-71a456daef8b", "AQAAAAEAACcQAAAAEMik6G5FvKRrHybCTyBaX1VB370/OKUVqL5QjSaeem0vYNN/NXhvJ25GEdJG4HeQxw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae78fff0-05db-4f3a-b3b5-ffcae7519927", "AQAAAAEAACcQAAAAEDYNG5VrZ+EAodff67BMnh4hHgSGIhH2v7394tDCYnaHwG1ps+41ZJJIy6vMW+2Vgw==" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DeletedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[,]
                {
                    { new Guid("944a0a3a-d91f-4b77-accb-c83deeecc3bb"), 1, new DateTime(2023, 8, 6, 18, 59, 7, 651, DateTimeKind.Local).AddTicks(6970), null, "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000, "Team Lead - Senior Developer" },
                    { new Guid("acb35b3b-b0ae-4b0e-829e-ab8fd61cac7b"), 2, new DateTime(2023, 8, 6, 18, 59, 7, 651, DateTimeKind.Local).AddTicks(7080), null, "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", null, "Sales Specialist" },
                    { new Guid("bb6b12d4-7a09-48e5-b20f-e870e4ed1295"), 4, new DateTime(2023, 8, 6, 18, 59, 7, 651, DateTimeKind.Local).AddTicks(7070), null, "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000, "Marketing & Content Manager" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("944a0a3a-d91f-4b77-accb-c83deeecc3bb"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("acb35b3b-b0ae-4b0e-829e-ab8fd61cac7b"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb6b12d4-7a09-48e5-b20f-e870e4ed1295"));

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
        }
    }
}
