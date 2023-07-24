namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data.Models.Job;
    using JobPortal.Web.ViewModels.Employer;
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

            await this.dbContext.Jobs.AddAsync(newJob);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string jobId)
        {
            var result = await this.dbContext.Jobs.AnyAsync(j => j.Id.ToString() == jobId);

            return result;
        }

        public async Task<JobAddFormModel> GetJobForEditByIdAsync(string jobId)
        {
            var job = await this.dbContext.Jobs
                .FirstAsync(j => j.Id.ToString() == jobId);

            return new JobAddFormModel
            {
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Salary = job.Salary,
                CategoryId = job.CategoryId,
            };
        }

        public async Task EditJobById(string jobId, JobAddFormModel model)
        {
            var job = await this.dbContext.Jobs.FirstAsync(j => j.Id.ToString() == jobId);

            job.Title = model.Title;
            job.Description = model.Description;
            job.Requirements = model.Requirements;
            job.Salary = model.Salary;
            job.CategoryId = model.CategoryId;
            
            await dbContext.SaveChangesAsync();
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

        public async Task<JobDetailsViewModel> GetJobDetailsByIdAsync(string jobId)
        {
            var job = await dbContext.Jobs
                .Include(j => j.Employer)
                .ThenInclude(e => e.User)
                .FirstAsync(j => j.Id.ToString() == jobId);

            var jobModel = new JobDetailsViewModel()
            {
                Id = job.Id.ToString(),
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Salary = job.Salary,
                EmployerInfo = new EmployerInfoViewModel()
                {
                    Name = job.Employer.User.UserName,
                    Email = job.Employer.User.Email,
                    PhoneNumber = job.Employer.PhoneNumber,
                    CompanyName = job.Employer.CompanyName,
                    CompanyAddress = job.Employer.CompanyAddress
                }
            };

            return jobModel;
        }
    }
}
