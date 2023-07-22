namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.ViewModels.Job;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class JobService : IJobService
    {
        private readonly JobPortalDbContext dbContext;
        public JobService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(string employerId, JobAddFormModel model)
        {
            var newJob = new Job()
            {
                Title = model.Title,
                Description = model.Description,
                Requirements = model.Requirements,
                Salary = model.Salary,
                CategoryId = model.CategoryId,
                EmployerId = Guid.Parse(employerId)
            };

            await dbContext.Jobs.AddAsync(newJob);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string jobId)
        {
            var result = await this.dbContext.Jobs.AnyAsync(j => j.Id.ToString() == jobId);

            return result;
        }

        public async Task<IEnumerable<JobViewModel>> GetAllJobsAsync()
        {
            var allJobs = await this.dbContext.Jobs
                .OrderByDescending(j => j.CreatedOn)
                .Select(j => new JobViewModel()
                {
                    Id = j.Id.ToString(),
                    Title = j.Title,
                    Salary = j.Salary,
                    CompanyName = j.Employer.CompanyName,
                    CompanyAddress = j.Employer.CompanyAddress
                })
                .ToListAsync();

            return allJobs;
        }

        public async Task<JobDetailsViewModel?> GetJobByIdAsync(string jobId)
        {
            var job = await dbContext.Jobs.Include(j => j.Employer).ThenInclude(e => e.User).FirstOrDefaultAsync(j => j.Id.ToString() == jobId);

            if (job == null)
            {
                return null;
            }

            var jobModel = new JobDetailsViewModel()
            {
                Id = job.Id.ToString(),
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Salary = job.Salary,
                EmployerName = job.Employer.User.UserName,
                CompanyName = job.Employer.CompanyName,
                CompanyAddress = job.Employer.CompanyAddress
            };

            return jobModel;
        }
    }
}
