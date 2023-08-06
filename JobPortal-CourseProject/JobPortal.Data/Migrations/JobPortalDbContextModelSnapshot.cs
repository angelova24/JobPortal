﻿// <auto-generated />
using System;
using JobPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPortal.Data.Migrations
{
    [DbContext(typeof(JobPortalDbContext))]
    partial class JobPortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JobPortal.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("LastName");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1d505412-e048-446d-87c9-d78ad2e8d328",
                            Email = "admin@test.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@test.com",
                            NormalizedUserName = "admin@test.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEHr8EUNrmxjWYol+9UqPMqxuD/IO8ULg8QofWLcas+MjNk7k34AfMrNJs7aAJp82xg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1ef229b1-4bfd-44eb-a12a-527a0df93d3d",
                            TwoFactorEnabled = false,
                            UserName = "admin@test.com"
                        },
                        new
                        {
                            Id = new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0713093a-098b-4ab8-a453-ccdbafede874",
                            Email = "employer@test.com",
                            EmailConfirmed = false,
                            FirstName = "Employer",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "employer@test.com",
                            NormalizedUserName = "employer@test.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELfvvv8iWkqUmk75r3tADQHdT5QbJR2Wt4ptMLkkScqW0np69kbf9mqY2aGjnjC7rg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "49380414-9ca7-4166-ad7a-5fd3afc11bd2",
                            TwoFactorEnabled = false,
                            UserName = "employer@test.com"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11ca2eab-637b-4453-a884-9af2789f8996"),
                            AuthorId = new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                            CreatedOn = new DateTime(2023, 8, 6, 19, 1, 8, 869, DateTimeKind.Local).AddTicks(9750),
                            Summary = "There’s nothing quite like a pandemic for prompting reflections on the truly big questions like “What do I want to do with my life?”.",
                            Text = "Lockdown has given us extra thinking time away from the hustle and bustle of the commute, the distractions of the open plan office and our busy personal lives.\r\nIt’s therefore unsurprising that according to a recent survey by Aviva, 60% of workers are planning a career change in what is being called “The Great Resignation”.  Sometimes it’s only when you step off the treadmill and see where you are, that you realise you want to be somewhere different.\r\nCorinne Mills, Managing Director of Personal Career Management a leading career coaching company, shares her insights on managing your career in a post-pandemic world, where the workplace and our relationship with it, is rapidly evolving.\r\nShape how you work\r\nThe pandemic has opened the possibilities of working in different ways.  Remote working has reduced many of the tensions associated with office life, such as a stressful commute, an overbearing boss or the interruptions of a shared communal space.  It’s also brought a new authenticity as we tend to be much more comfortable within our domestic setting than the performance playground of the office.  No wonder that according to the EY 2021 Work Reimagined Survey,.4 out of 5 workers say that they would find another job rather than go back to work in the office full-time.\r\nYet while there are undoubted benefits of flexible working, there are career risks in this too. It would be very easy for your professional world to become small and transactional.  This leaves you in danger of being overlooked and therefore vulnerable.  It’s much harder to build wider and substantive relationships with people when there’s few opportunities to mingle but it is going to become even more important that you do.\r\nDeveloping your visibility post-pandemic doesn’t only mean updating your LinkedIn.  You’ll need to find opportunities to grow your job and get in front of key people.  Talk to your boss about how in addition to working on your key tasks, you might also develop particular areas you are interested in, especially if they give you exposure to new people and other parts of the business. \r\nAsk for a mentor, offer to become a brand ambassador or internal champion for internal well-being or charity initiatives.  Volunteer for projects that are cross-organisational, or suggest that you spend time talking to customers, suppliers, or stakeholders, to gather research or investigate a long-standing issue.\r\nExternally you also need to be networking.  This might be through a relevant professional group or association.  There are so many available and most of them are running virtual events. If and when you are in the office, use it to have face to face discussions with as many people as you can, including scheduling after work meet-ups.\r\nWe may have sensibly retreated to our cave during the pandemic, but if we stay there, we lose the richness and energy of interacting with different people who we can learn from and who may be able to help us with our career.",
                            Title = "Making a Career Change. Career Advice for a Post-Pandemic Workplace"
                        },
                        new
                        {
                            Id = new Guid("037c7cb1-f921-4660-8717-6a7a704dd224"),
                            AuthorId = new Guid("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                            CreatedOn = new DateTime(2023, 8, 6, 19, 1, 8, 869, DateTimeKind.Local).AddTicks(9790),
                            Summary = "So at a time of huge societal disruption, how do you shift your career to a place that better reflects your new priorities while still protecting your livelihood? Here’s our essential tips.",
                            Text = "It’s amazing how quickly most of us have adapted to home working.  We’ve got past the giggly phase of seeing ourselves on video calls and waving goodbye like a toddler.  We’ve also become far more relaxed about interruptions from children, cats and snoring dogs as we ditch the smart office attire, cut our own fringes and dispense with shoes.  For many people this has been a positive change, a liberation from the commute and office politics.\r\nIt’s also given us time to think about our life and career priorities.  While people are understandably keen to hang onto their jobs given the widespread redundancies and difficult job market, many people are also realising that the career path they’ve been treading is no longer as attractive or even as viable as it had been pre-pandemic.\r\nSo at a time of huge societal disruption, how do you shift your career to a place that better reflects your new priorities while still protecting your livelihood?  Here’s our essential tips.\r\nInternal PR\r\nAs a career coach at Personal Career Management, I talk every day with individuals who thought their job was safe until the moment they were told they would be leaving.  Positively managing your reputation within your organisation needs to be an ongoing activity and this becomes especially important if you are working remotely and are less visible.  Share your successes with your boss and other key decision-makers rather than just the problems.  Reminding them what an asset you are will help position you for career development opportunities or encourage them to redeploy you, if there are redundancies.\r\nThink radical\r\nVirtual events, healthcare consultations via skype and restaurant food home deliveries are just a few examples of organisations thinking creatively about how to continue their operations and identify new revenue streams.   Share any ideas you have that could help your company make sense of the new landscape and suggest you take a lead on this to scope out its potential.  It’s an interesting career building development opportunity for you, increases your visibility and helps the organisation too.\r\nRamp up your learning\r\nEmployees have to be agile to contend with the fast-changing landscape.  If you have a growth mind-set and a demonstrated willingness to learn then you will be more employable and more likely to be retained.  It’s smart to make learning a regular habit.  Seek out new learning opportunities at work and externally as there are so many accessible learning opportunities right now, whether it is free webinars, online study courses or even a part-time University degree or MBA.\r\nThe career positives of a crisis\r\nFor many of us, the pandemic has brought some of the most difficult professional challenges of our career.  Maybe you’ve had to re-jig operations, reassure anxious customers and staff, handle  furloughing or staff redundancies.  Perhaps you volunteered for community work, helping people in your street or a local charity.  You may have done all of these things simply because it was your job or you wanted to be useful.  However, what they reveal is your resilience and resourcefulness, your ability to get things done even in the midst of a crisis.  Future employers will definitely want to hear about these mettle-testing career achievements so speak up about them.\r\nDon’t worry about a career derail\r\nIf you find yourself needing to take on a role which isn’t necessarily your first choice, then don’t worry about whether it will affect your future prospects.  Ordinarily employers are suspicious about career change or detours, but in these unusual circumstances, most of them fully appreciate that individuals need to be pragmatic and versatile in order to pay their bills.  You will still need to show motivation and perform well in whatever role you undertake, but this doesn’t stop you from continuing to look for your more ideal role.\r\nGo where the demand is\r\nSome sectors such as technology, supermarkets and healthcare  are in growth mode while others such as the High street retail, travel, tourism and live arts are sadly struggling right now.   Read the business news and reports by recruitment agencies to find out which sectors are recruiting.   Explore the companies who operate in these spaces and the roles they have where you could use your transferable skills.  Use LinkedIn to identify individuals you know who work in these areas and who could give you advice and suggest a way in for you.\r\nSide hustle\r\nIf you’re no longer commuting, perhaps you have additional bandwidth to consider other supplementary ways to boost your income.  Perhaps you could offer online tutoring in your area of expertise, renovate a property, create an online artisan shop, or offer graphic design services or mentoring.  Portfolio working is going to become increasingly common as individuals working from home use their new flexibility to balance different interests and income streams.\r\nCut yourself some slack\r\nThe pandemic has reminded us that life is precious and while work is necessary and can be life-affirming, it shouldn’t be all-consuming.   Despite this, burn-out has become another symptom of this pandemic with many individuals feeling increasingly exhausted by the professional and personal challenges they face.  Build activities into your week which are enjoyable and completely removed from work.  Find your off-switch and recharge.\r\nThe key is other people\r\nOur restricted work and social bubbles may keep us safer but they’ve also made it more difficult to use the most effective career management strategy there is, namely our relationships with other people.  Engaging with others increases our visibility, helps us positively influence perceptions and builds our reputation as someone who would be good to work with or who can be recommended to others. Advice and feedback helps confirm we are on the right track and where we need to develop.  We hear from others about opportunities that we otherwise would have missed.\r\nIt’s important that you create opportunities for dialogue with key influencers at work, get in touch with your connections and join online networking groups to extend your circle.  Working with a career coach as a guide and sounding board can be enormously helpful with tricky career challenges  and building confidence.  Other people will help you but it’s up to you to reach out to them.",
                            Title = "10 Essential Career-Boosting and Career Survival Tips for Managing your Career during a Pandemic"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sales"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Marketing and communication"
                        },
                        new
                        {
                            Id = 5,
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.Employer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Employers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"),
                            CompanyAddress = "Sofia",
                            CompanyName = "Awesome Company",
                            PhoneNumber = "+359888888888",
                            UserId = new Guid("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855")
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmployerId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("92f2a645-3f70-472a-9615-95e12311b7f3"),
                            CategoryId = 1,
                            CreatedOn = new DateTime(2023, 8, 6, 19, 1, 8, 870, DateTimeKind.Local).AddTicks(1270),
                            Description = "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.",
                            EmployerId = new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"),
                            Requirements = "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.",
                            Salary = 100000,
                            Title = "Team Lead - Senior Developer"
                        },
                        new
                        {
                            Id = new Guid("224aff89-9e46-493f-99c4-6e4ddf579bc7"),
                            CategoryId = 4,
                            CreatedOn = new DateTime(2023, 8, 6, 19, 1, 8, 870, DateTimeKind.Local).AddTicks(1290),
                            Description = "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.",
                            EmployerId = new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"),
                            Requirements = "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams",
                            Salary = 90000,
                            Title = "Marketing & Content Manager"
                        },
                        new
                        {
                            Id = new Guid("5e67a0c6-e5ea-4553-869a-2dd726dd9af5"),
                            CategoryId = 2,
                            CreatedOn = new DateTime(2023, 8, 6, 19, 1, 8, 870, DateTimeKind.Local).AddTicks(1300),
                            Description = "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.",
                            EmployerId = new Guid("aa294071-5c7d-4f4c-8451-42fac506957c"),
                            Requirements = "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.",
                            Title = "Sales Specialist"
                        });
                });

            modelBuilder.Entity("JobPortal.Data.Models.UserJobs", b =>
                {
                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("CandidateId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("UserJobs", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobPortal.Data.Models.Article", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Employer", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Job", b =>
                {
                    b.HasOne("JobPortal.Data.Models.Category", "Category")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Employer", "Employer")
                        .WithMany("JobOffers")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobPortal.Data.Models.UserJobs", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", "Candidate")
                        .WithMany("JobApplications")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.Job", "Job")
                        .WithMany("Candidates")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("JobPortal.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobPortal.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Category", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Employer", b =>
                {
                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("JobPortal.Data.Models.Job", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
