using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class AddCreatedOnToMappingTableUserJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserJob");

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

            migrationBuilder.CreateTable(
                name: "UserJobs",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobs", x => new { x.CandidateId, x.JobId });
                    table.ForeignKey(
                        name: "FK_UserJobs_AspNetUsers_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserJobs_JobId",
                table: "UserJobs",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJobs");

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

            migrationBuilder.CreateTable(
                name: "ApplicationUserJob",
                columns: table => new
                {
                    CandidatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobApplicationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserJob", x => new { x.CandidatesId, x.JobApplicationsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserJob_AspNetUsers_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserJob_Jobs_JobApplicationsId",
                        column: x => x.JobApplicationsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserJob_JobApplicationsId",
                table: "ApplicationUserJob",
                column: "JobApplicationsId");
        }
    }
}
