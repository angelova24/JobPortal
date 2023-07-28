using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class SoftDeleteJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("3384aeb6-1da5-4be1-8520-ed29d1c09816"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("50c858f9-ff8c-4db7-812c-33f8850639b2"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("7f17284b-d4ac-4e55-9db3-87f3addcc6cd"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DeletedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("14b291e9-ff0d-4afd-9e4c-f0b971b3affe"), 2, new DateTime(2023, 7, 28, 17, 38, 38, 916, DateTimeKind.Local).AddTicks(5320), null, "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", null, "Sales Specialist" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DeletedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("5f9d4270-c23d-461a-b095-1ce7fd13ad93"), 4, new DateTime(2023, 7, 28, 17, 38, 38, 916, DateTimeKind.Local).AddTicks(5310), null, "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000, "Marketing & Content Manager" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DeletedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("6ba626e3-c503-49fa-bd4c-5f676dbdfa68"), 1, new DateTime(2023, 7, 28, 17, 38, 38, 916, DateTimeKind.Local).AddTicks(5180), null, "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000, "Team Lead - Senior Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("14b291e9-ff0d-4afd-9e4c-f0b971b3affe"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("5f9d4270-c23d-461a-b095-1ce7fd13ad93"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("6ba626e3-c503-49fa-bd4c-5f676dbdfa68"));

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Jobs");

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("3384aeb6-1da5-4be1-8520-ed29d1c09816"), 1, new DateTime(2023, 7, 22, 18, 22, 21, 189, DateTimeKind.Local).AddTicks(4086), "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000, "Team Lead - Senior Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("50c858f9-ff8c-4db7-812c-33f8850639b2"), 4, new DateTime(2023, 7, 22, 18, 22, 21, 189, DateTimeKind.Local).AddTicks(4179), "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000, "Marketing & Content Manager" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("7f17284b-d4ac-4e55-9db3-87f3addcc6cd"), 2, new DateTime(2023, 7, 22, 18, 22, 21, 189, DateTimeKind.Local).AddTicks(4187), "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", null, "Sales Specialist" });
        }
    }
}
