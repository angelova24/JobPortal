namespace JobPortal.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
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
            
            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var users = new HashSet<ApplicationUser>();
            
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
            users.Add(adminUser);
            
            var employerUser = new ApplicationUser()
            {
                Id = Guid.Parse("262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855"),
                UserName = "employer@test.com",
                NormalizedUserName = "employer@test.com",
                Email = "employer@test.com",
                NormalizedEmail = "employer@test.com",
                FirstName = "Employer",
                LastName = "User",
                SecurityStamp = "49380414-9ca7-4166-ad7a-5fd3afc11bd2"
            };
            employerUser.PasswordHash = hasher.HashPassword(employerUser, "123456");
            users.Add(employerUser);
            
            return users.ToArray();
        }
    }
}