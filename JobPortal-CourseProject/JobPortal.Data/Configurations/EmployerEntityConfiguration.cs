namespace JobPortal.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class EmployerEntityConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasData(GenerateEmployer());
        }
        
        private Employer GenerateEmployer()
        {
            var employer = new Employer()
            {
                Id = Guid.Parse("aa294071-5c7d-4f4c-8451-42fac506957c"),
                CompanyName = "Awesome Company",
                CompanyAddress = "Sofia",
                PhoneNumber = "+359888888888",
                UserId = Guid.Parse("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855")
            };

            return employer;
        }
    }
}