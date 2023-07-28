namespace JobPortal.Data.Configurations
{
    using JobPortal.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JobEntityConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasQueryFilter(job => !job.DeletedOn.HasValue);
            
            builder
                .HasOne(j => j.Category)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(j => j.Employer)
                .WithMany(e => e.JobOffers)
                .HasForeignKey(j => j.EmployerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateJobs());
        }

        private Job[] GenerateJobs()
        {
            ICollection<Job> jobs = new HashSet<Job>();

            Job job;

            job = new Job()
            {
                Title = "Team Lead - Senior Developer",
                Description = "Our client is a leading workplace technology company with headquarters in Switzerland, Fribourg. They help companies manage their workspaces efficiently while boosting employee satisfaction.They need a Team Lead - Senior Developer to shape their technical direction, driving their growth, and building trust with thei valued customers.",
                Requirements = "Master degree in computer science or equivalent.\r\nA strong background in (agile) software development.\r\nExperience in C#/.Net and Microsoft Azure software architecture.\r\nExperience in web technologies\r\nProven experience in defining and specifying IT architecture.\r\nKnowledgeable in IT-security and GDPR related topics.\r\nAbility to build, lead and motivate a high-performing software engineering team.\r\nExcellent communication and interpersonal skills.\r\nFluency in German and English.",
                Salary = 100000,
                CategoryId = 1,
                EmployerId = Guid.Parse("AA294071-5C7D-4F4C-8451-42FAC506957C")
            };
            jobs.Add(job);

            job = new Job()
            {
                Title = "Marketing & Content Manager",
                Description = "As a Partnerships Manager, you will leverage your knowledge and experience to outreach, prospect, and qualify leads by understanding their business needs and moving them through the sales pipeline.\r\nYou will be passionate and experienced in the loyalty industry and web3 technology, have a proven track record as SDR in tech B2B for SaaS, be tech-savvy, and own a beast-mode and highly ambitious mindset.",
                Requirements = "5+ years experience in digital marketing/sales, including brand management, marketing communications, and content strategy\r\nExpertise in multiple marketing channels, including paid, owned, earned, broadcast, and digital\r\nSkilled in managing and creating content for paid online media\r\nAdvanced qualifications in marketing strategy\r\nStrong data analysis abilities to make informed decisions\r\nExcellent communication skills in English and German, and ability to thrive in collaborative teams",
                Salary = 90000,
                CategoryId = 4,
                EmployerId = Guid.Parse("AA294071-5C7D-4F4C-8451-42FAC506957C")
            };
            jobs.Add(job);

            job = new Job()
            {
                Title = "Sales Specialist",
                Description = "WE ARE LOOKING FOR Sales Specialists for the Croatian market \r\n\r\nWe are fast growing company from the retail segment of the health & beauty industry. We sells natural dietary supplements and cosmetics. We are developing our structures, building new teams, developing foreign markets in our structures and now we are waiting for you.",
                Requirements = "Necessary condition: very good knowledge of the language Croatian (C1/C2) \r\n\r\nImportant - knowledge of English or Polish at a level that allows active participation in training\r\n\r\nFull commitment to absorbing new knowledge and putting it into practice. \r\n\r\nDesire for constant development and openness to changes. \r\n\r\nDiscipline and willingness to work intensively and regularly. \r\n\r\nGreat courage, creativity and perseverance in pursuit of the goal.",
                CategoryId = 2,
                EmployerId = Guid.Parse("AA294071-5C7D-4F4C-8451-42FAC506957C")
            };
            jobs.Add(job);

            return jobs.ToArray();
        }
    }
}
