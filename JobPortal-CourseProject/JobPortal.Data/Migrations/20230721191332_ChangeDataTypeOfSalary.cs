using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class ChangeDataTypeOfSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("3c4b7c25-ad65-4e70-af94-f2f665f34894"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("4aa281f9-011d-4add-809d-52e8c3ecf3bc"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("942188ca-67d5-4ca3-af45-1c9a01274a97"));

            migrationBuilder.AlterColumn<int>(
                name: "Salary",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("53d93b5f-5b53-4c96-a6aa-5849944106c5"), 1, new DateTime(2023, 7, 21, 21, 13, 31, 975, DateTimeKind.Local).AddTicks(3824), "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000, "Team Lead - Senior Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("653fbb23-067c-46f4-9658-c9837906396c"), 2, new DateTime(2023, 7, 21, 21, 13, 31, 975, DateTimeKind.Local).AddTicks(3934), "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", null, "Sales Specialist" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("7dfcbc28-9a85-4d73-826a-befe42eaf7d5"), 4, new DateTime(2023, 7, 21, 21, 13, 31, 975, DateTimeKind.Local).AddTicks(3926), "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000, "Marketing & Content Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("53d93b5f-5b53-4c96-a6aa-5849944106c5"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("653fbb23-067c-46f4-9658-c9837906396c"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("7dfcbc28-9a85-4d73-826a-befe42eaf7d5"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("3c4b7c25-ad65-4e70-af94-f2f665f34894"), 1, new DateTime(2023, 7, 21, 16, 24, 19, 384, DateTimeKind.Local).AddTicks(2910), "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000m, "Team Lead - Senior Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("4aa281f9-011d-4add-809d-52e8c3ecf3bc"), 4, new DateTime(2023, 7, 21, 16, 24, 19, 384, DateTimeKind.Local).AddTicks(3071), "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000m, "Marketing & Content Manager" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[] { new Guid("942188ca-67d5-4ca3-af45-1c9a01274a97"), 2, new DateTime(2023, 7, 21, 16, 24, 19, 384, DateTimeKind.Local).AddTicks(3081), "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", 0m, "Sales Specialist" });
        }
    }
}
