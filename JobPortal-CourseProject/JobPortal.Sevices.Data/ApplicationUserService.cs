namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Sevices.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly JobPortalDbContext dbContext;

        public ApplicationUserService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ApplyForJobAsync(string userId, string jobId)
        {
            var candidature = new UserJobs()
            {
                CandidateId = Guid.Parse(userId),
                JobId = Guid.Parse(jobId)
            };

            await dbContext.UserJobs.AddAsync(candidature);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasAppliedForThatJobAsync(string userId, string jobId)
        {
            var candidature = await dbContext.UserJobs
                .FirstOrDefaultAsync(x => x.CandidateId.ToString() == userId && x.JobId.ToString() == jobId);

            if (candidature == null)
            {
                return false;
            }

            return true;
        }
    }
}
