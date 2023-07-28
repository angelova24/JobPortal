namespace JobPortal.Data
{
    using JobPortal.Data.Models;
    using JobPortal.Data.Models.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class JobPortalDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Employer> Employers { get; set; } = null!;

        public DbSet<Job> Jobs { get; set; } = null!;

        public DbSet<UserJobs> UserJobs { get; set; } = null!;
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries() 
                         .Where(p => p.State == EntityState.Deleted))
            {
                if (entry.Entity is ISoftDeletable entity)
                {
                    entry.State = EntityState.Unchanged;
                    entity.DeletedOn = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var configAssembly = Assembly.GetAssembly(typeof(JobPortalDbContext)) ??
                                 Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}