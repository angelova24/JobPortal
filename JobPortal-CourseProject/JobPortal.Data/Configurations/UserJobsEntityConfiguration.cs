namespace JobPortal.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserJobsEntityConfiguration : IEntityTypeConfiguration<UserJobs>
    {
        public void Configure(EntityTypeBuilder<UserJobs> builder)
        {
            builder.ToTable("UserJobs").HasKey(x => new {x.CandidateId, x.JobId});
        }
    }
}
