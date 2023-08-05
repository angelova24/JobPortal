using Microsoft.AspNetCore.Identity;

namespace JobPortal.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("FirstName");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("LastName");

            builder.HasData(GenerateUser());
        }

        private ApplicationUser GenerateUser()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            
            var adminUser = new ApplicationUser()
            {
                Id = Guid.Parse("e30fae8e-5a56-4112-9250-aff3affb75a4"),
                UserName = "admin@test.com",
                NormalizedUserName = "admin@test.com",
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com",
                FirstName = "Admin",
                LastName = "User",
                SecurityStamp = "1ef229b1-4bfd-44eb-a12a-527a0df93d3d"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin1234");

            return adminUser;
        }
    }
}