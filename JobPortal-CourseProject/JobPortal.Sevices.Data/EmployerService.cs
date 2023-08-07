namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using Interfaces;
    using Web.ViewModels.Employer;
    using Web.ViewModels.Job;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels.User;

    public class EmployerService : IEmployerService
    {
        private readonly JobPortalDbContext dbContext;
        public EmployerService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(string userId, BecomeEmployerFormModel model)
        {
            var newEmployer = new Employer()
            {
                CompanyName = model.CompanyName,
                CompanyAddress = model.CompanyAddress,
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await dbContext.AddAsync(newEmployer);
            await dbContext.SaveChangesAsync();
        }


        public async Task<bool> EmployerExistsByPhoneNumberAsync(string phoneNumber)
        {
            var result = await dbContext.Employers.AnyAsync(e => e.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> EmployerExistsByUserIdAsync(string userId)
        {
            var result = await dbContext.Employers.AnyAsync(e => e.UserId.ToString() == userId);

            return result;
        }

        public async Task<string?> GetEmployerIdByUserIdAsync(string userId)
        {
            var employer = await dbContext.Employers.FirstOrDefaultAsync(e => e.UserId.ToString() == userId);

            if (employer == null)
            {
                return null;
            }

            return employer.Id.ToString();
        }

        public async Task<IEnumerable<JobViewModel>> GetAllJobsByEmployerIdAsync(string employerId)
        {
            var allEmployerJobs = await dbContext.Jobs
                .Where(j => j.EmployerId.ToString() == employerId)
                .Select(j => new JobViewModel()
                {
                    Id = j.Id.ToString(),
                    Title = j.Title,
                    Salary = j.Salary,
                    CompanyName = j.Employer.CompanyName,
                    CompanyAddress = j.Employer.CompanyAddress,
                    CreatedOn = j.CreatedOn
                })
                .OrderByDescending(j => j.CreatedOn)
                .ToListAsync();

            return allEmployerJobs;
        }

        public async Task<bool> IsAuthorOfJobByUserIdAsync(string userId, string jobId)
        {
            var isAuthor = await dbContext.Jobs.AnyAsync(j => j.Id.ToString() == jobId && j.Employer.UserId.ToString() == userId);

            return isAuthor;
        }

        public async Task<IEnumerable<CandidateViewModel>> GetAllCandidatesByJobIdAsync(string jobId)
        {
            var candidates = await dbContext.UserJobs
                .Where(uj => uj.JobId.ToString() == jobId)
                .Select(uj => new CandidateViewModel()
                {
                    Id = uj.CandidateId.ToString(),
                    FullName = uj.Candidate.FirstName + " " + uj.Candidate.LastName,
                    Email = uj.Candidate.Email,
                    ApplicationDate = uj.CreatedOn
                })
                .OrderBy(c => c.ApplicationDate)
                .ToListAsync();

            return candidates;
        }
    }
}
