namespace JobPortal.Data.Configurations
{
    using JobPortal.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserJobsEntityConfiguration : IEntityTypeConfiguration<UserJobs>
    {
        public void Configure(EntityTypeBuilder<UserJobs> builder)
        {
            builder.ToTable("UserJobs").HasKey(x => new {x.CandidateId, x.JobId});
        }
    }
}
