namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.ViewModels.Job;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using static JobPortal.Common.EntityValidationConstants;

    public class UserService : IUserService
    {
        private readonly JobPortalDbContext dbContext;

        public UserService(JobPortalDbContext dbContext)
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

        public async Task<IEnumerable<JobViewModel>> GetAllJobsByCandidateIdAsync(string candidateId)
        {
            var userApplicationJobs = await dbContext.UserJobs
                .Where(uj => uj.CandidateId.ToString() == candidateId)
                .Select(uj => new JobViewModel()
                {
                    Id = uj.JobId.ToString(),
                    Title = uj.Job.Title,
                    Salary = uj.Job.Salary,
                    CompanyName = uj.Job.Employer.CompanyName,
                    CompanyAddress = uj.Job.Employer.CompanyAddress
                })
                .ToListAsync();

            return userApplicationJobs;
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
