namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data.Models.Job;
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.ViewModels.Job;
    using JobPortal.Web.ViewModels.Job.Enums;
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

        public async Task<JobsFilteredAndPagedServiceModel> GetAllJobsAsync(JobsQueryModel queryModel)
        {
            var jobsQuery = this.dbContext.Jobs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                jobsQuery = jobsQuery.Where(j => j.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                var wildcard = $"%{queryModel.SearchTerm.ToLower()}%";

                jobsQuery = jobsQuery
                    .Where(j => EF.Functions.Like(j.Title, wildcard) || 
                                EF.Functions.Like(j.Description, wildcard) ||
                                EF.Functions.Like(j.Requirements, wildcard));
            }

            jobsQuery = queryModel.JobSorting switch
            {
                JobSorting.Newest => jobsQuery.OrderByDescending(j => j.CreatedOn),
                JobSorting.Oldest => jobsQuery.OrderBy(j => j.CreatedOn),
                JobSorting.BestPaid => jobsQuery.OrderByDescending(j => j.Salary),
                _ => jobsQuery.OrderByDescending(j => j.CreatedOn)
            };

            var allJobs = await jobsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.JobsPerPage)
                .Take(queryModel.JobsPerPage)
                .Select(j => new JobViewModel()
                {
                    Id = j.Id.ToString(),
                    Title = j.Title,
                    Salary = j.Salary,
                    CompanyName = j.Employer.CompanyName,
                    CompanyAddress = j.Employer.CompanyAddress
                })
                .ToListAsync();

            var totalJobs = jobsQuery.Count();

            return new JobsFilteredAndPagedServiceModel()
            {
                JobsCount = totalJobs,
                Jobs = allJobs
            };
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
