using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class AddArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("0a28dc77-511b-4e8c-a71d-41eb93bda068"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("e98975bc-d055-4723-90c7-b90f1bd0ddec"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("f852844b-9436-48b3-89fe-762d3a7d7504"));

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "Summary", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("5c68d020-8550-4796-8143-61ae85e2c938"), new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"), new DateTime(2023, 8, 5, 22, 20, 5, 816, DateTimeKind.Local).AddTicks(8340), "There’s nothing quite like a pandemic for prompting reflections on the truly big questions like “What do I want to do with my life?”.", "Lockdown has given us extra thinking time away from the hustle and bustle of the commute, the distractions of the open plan office and our busy personal lives.\r\nIt’s therefore unsurprising that according to a recent survey by Aviva, 60% of workers are planning a career change in what is being called “The Great Resignation”.  Sometimes it’s only when you step off the treadmill and see where you are, that you realise you want to be somewhere different.\r\nCorinne Mills, Managing Director of Personal Career Management a leading career coaching company, shares her insights on managing your career in a post-pandemic world, where the workplace and our relationship with it, is rapidly evolving.\r\nShape how you work\r\nThe pandemic has opened the possibilities of working in different ways.  Remote working has reduced many of the tensions associated with office life, such as a stressful commute, an overbearing boss or the interruptions of a shared communal space.  It’s also brought a new authenticity as we tend to be much more comfortable within our domestic setting than the performance playground of the office.  No wonder that according to the EY 2021 Work Reimagined Survey,.4 out of 5 workers say that they would find another job rather than go back to work in the office full-time.\r\nYet while there are undoubted benefits of flexible working, there are career risks in this too. It would be very easy for your professional world to become small and transactional.  This leaves you in danger of being overlooked and therefore vulnerable.  It’s much harder to build wider and substantive relationships with people when there’s few opportunities to mingle but it is going to become even more important that you do.\r\nDeveloping your visibility post-pandemic doesn’t only mean updating your LinkedIn.  You’ll need to find opportunities to grow your job and get in front of key people.  Talk to your boss about how in addition to working on your key tasks, you might also develop particular areas you are interested in, especially if they give you exposure to new people and other parts of the business. \r\nAsk for a mentor, offer to become a brand ambassador or internal champion for internal well-being or charity initiatives.  Volunteer for projects that are cross-organisational, or suggest that you spend time talking to customers, suppliers, or stakeholders, to gather research or investigate a long-standing issue.\r\nExternally you also need to be networking.  This might be through a relevant professional group or association.  There are so many available and most of them are running virtual events. If and when you are in the office, use it to have face to face discussions with as many people as you can, including scheduling after work meet-ups.\r\nWe may have sensibly retreated to our cave during the pandemic, but if we stay there, we lose the richness and energy of interacting with different people who we can learn from and who may be able to help us with our career.", "Making a Career Change. Career Advice for a Post-Pandemic Workplace" },
                    { new Guid("8685a8a5-30e3-49b3-a082-0d8a3ac6e03d"), new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"), new DateTime(2023, 8, 5, 22, 20, 5, 816, DateTimeKind.Local).AddTicks(8400), "So at a time of huge societal disruption, how do you shift your career to a place that better reflects your new priorities while still protecting your livelihood? Here’s our essential tips.", "It’s amazing how quickly most of us have adapted to home working.  We’ve got past the giggly phase of seeing ourselves on video calls and waving goodbye like a toddler.  We’ve also become far more relaxed about interruptions from children, cats and snoring dogs as we ditch the smart office attire, cut our own fringes and dispense with shoes.  For many people this has been a positive change, a liberation from the commute and office politics.\r\nIt’s also given us time to think about our life and career priorities.  While people are understandably keen to hang onto their jobs given the widespread redundancies and difficult job market, many people are also realising that the career path they’ve been treading is no longer as attractive or even as viable as it had been pre-pandemic.\r\nSo at a time of huge societal disruption, how do you shift your career to a place that better reflects your new priorities while still protecting your livelihood?  Here’s our essential tips.\r\nInternal PR\r\nAs a career coach at Personal Career Management, I talk every day with individuals who thought their job was safe until the moment they were told they would be leaving.  Positively managing your reputation within your organisation needs to be an ongoing activity and this becomes especially important if you are working remotely and are less visible.  Share your successes with your boss and other key decision-makers rather than just the problems.  Reminding them what an asset you are will help position you for career development opportunities or encourage them to redeploy you, if there are redundancies.\r\nThink radical\r\nVirtual events, healthcare consultations via skype and restaurant food home deliveries are just a few examples of organisations thinking creatively about how to continue their operations and identify new revenue streams.   Share any ideas you have that could help your company make sense of the new landscape and suggest you take a lead on this to scope out its potential.  It’s an interesting career building development opportunity for you, increases your visibility and helps the organisation too.\r\nRamp up your learning\r\nEmployees have to be agile to contend with the fast-changing landscape.  If you have a growth mind-set and a demonstrated willingness to learn then you will be more employable and more likely to be retained.  It’s smart to make learning a regular habit.  Seek out new learning opportunities at work and externally as there are so many accessible learning opportunities right now, whether it is free webinars, online study courses or even a part-time University degree or MBA.\r\nThe career positives of a crisis\r\nFor many of us, the pandemic has brought some of the most difficult professional challenges of our career.  Maybe you’ve had to re-jig operations, reassure anxious customers and staff, handle  furloughing or staff redundancies.  Perhaps you volunteered for community work, helping people in your street or a local charity.  You may have done all of these things simply because it was your job or you wanted to be useful.  However, what they reveal is your resilience and resourcefulness, your ability to get things done even in the midst of a crisis.  Future employers will definitely want to hear about these mettle-testing career achievements so speak up about them.\r\nDon’t worry about a career derail\r\nIf you find yourself needing to take on a role which isn’t necessarily your first choice, then don’t worry about whether it will affect your future prospects.  Ordinarily employers are suspicious about career change or detours, but in these unusual circumstances, most of them fully appreciate that individuals need to be pragmatic and versatile in order to pay their bills.  You will still need to show motivation and perform well in whatever role you undertake, but this doesn’t stop you from continuing to look for your more ideal role.\r\nGo where the demand is\r\nSome sectors such as technology, supermarkets and healthcare  are in growth mode while others such as the High street retail, travel, tourism and live arts are sadly struggling right now.   Read the business news and reports by recruitment agencies to find out which sectors are recruiting.   Explore the companies who operate in these spaces and the roles they have where you could use your transferable skills.  Use LinkedIn to identify individuals you know who work in these areas and who could give you advice and suggest a way in for you.\r\nSide hustle\r\nIf you’re no longer commuting, perhaps you have additional bandwidth to consider other supplementary ways to boost your income.  Perhaps you could offer online tutoring in your area of expertise, renovate a property, create an online artisan shop, or offer graphic design services or mentoring.  Portfolio working is going to become increasingly common as individuals working from home use their new flexibility to balance different interests and income streams.\r\nCut yourself some slack\r\nThe pandemic has reminded us that life is precious and while work is necessary and can be life-affirming, it shouldn’t be all-consuming.   Despite this, burn-out has become another symptom of this pandemic with many individuals feeling increasingly exhausted by the professional and personal challenges they face.  Build activities into your week which are enjoyable and completely removed from work.  Find your off-switch and recharge.\r\nThe key is other people\r\nOur restricted work and social bubbles may keep us safer but they’ve also made it more difficult to use the most effective career management strategy there is, namely our relationships with other people.  Engaging with others increases our visibility, helps us positively influence perceptions and builds our reputation as someone who would be good to work with or who can be recommended to others. Advice and feedback helps confirm we are on the right track and where we need to develop.  We hear from others about opportunities that we otherwise would have missed.\r\nIt’s important that you create opportunities for dialogue with key influencers at work, get in touch with your connections and join online networking groups to extend your circle.  Working with a career coach as a guide and sounding board can be enormously helpful with tricky career challenges  and building confidence.  Other people will help you but it’s up to you to reach out to them.", "10 Essential Career-Boosting and Career Survival Tips for Managing your Career during a Pandemic" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd5e410c-c7b6-44db-b7e2-47ed240a94c8", "AQAAAAEAACcQAAAAELfzO0j8mQnxGh+pw0WJThh09FSzfX4+2p3bky+KCLRKw0CiHPI8OXxaUeq97epODg==" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DeletedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[,]
                {
                    { new Guid("2f2dfc53-0d6b-4c60-b896-f46ed185a5e6"), 4, new DateTime(2023, 8, 5, 22, 20, 5, 816, DateTimeKind.Local).AddTicks(9790), null, "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000, "Marketing & Content Manager" },
                    { new Guid("80ae0ab5-523e-4596-ab65-3b7e3bd0845e"), 1, new DateTime(2023, 8, 5, 22, 20, 5, 816, DateTimeKind.Local).AddTicks(9770), null, "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000, "Team Lead - Senior Developer" },
                    { new Guid("dec52b5c-aa9d-4a45-86e9-1ec870817237"), 2, new DateTime(2023, 8, 5, 22, 20, 5, 816, DateTimeKind.Local).AddTicks(9810), null, "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", null, "Sales Specialist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("2f2dfc53-0d6b-4c60-b896-f46ed185a5e6"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("80ae0ab5-523e-4596-ab65-3b7e3bd0845e"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("dec52b5c-aa9d-4a45-86e9-1ec870817237"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8b22ccc-f881-4099-aa75-7a59201fa91b", "AQAAAAEAACcQAAAAEIp+6+y8yLhkIPGvMnuv4X4Hivy3hyfu7m6V8gJtzqAcrRs0ghNCIlCb2Q+ZiF7uzA==" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DeletedOn", "Description", "EmployerId", "Requirements", "Salary", "Title" },
                values: new object[,]
                {
                    { new Guid("0a28dc77-511b-4e8c-a71d-41eb93bda068"), 2, new DateTime(2023, 8, 5, 19, 4, 30, 866, DateTimeKind.Local).AddTicks(9910), null, "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.", null, "Sales Specialist" },
                    { new Guid("e98975bc-d055-4723-90c7-b90f1bd0ddec"), 1, new DateTime(2023, 8, 5, 19, 4, 30, 866, DateTimeKind.Local).AddTicks(9820), null, "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.", 100000, "Team Lead - Senior Developer" },
                    { new Guid("f852844b-9436-48b3-89fe-762d3a7d7504"), 4, new DateTime(2023, 8, 5, 19, 4, 30, 866, DateTimeKind.Local).AddTicks(9900), null, "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.", new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"), "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams", 90000, "Marketing & Content Manager" }
                });
        }
    }
}
