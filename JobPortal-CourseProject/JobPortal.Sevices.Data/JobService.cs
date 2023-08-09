namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data.Models.Job;
    using Web.ViewModels.Employer;
    using Interfaces;
    using Web.ViewModels.Job;
    using Web.ViewModels.Job.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class JobService : IJobService
    {
        private readonly JobPortalDbContext dbContext;
        
        public JobService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> CreateAndReturnIdAsync(string employerId, JobAddFormModel model)
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

            return newJob.Id.ToString();
        }

        public async Task<bool> ExistsByIdAsync(string jobId)
        {
            var result = await dbContext.Jobs.AnyAsync(j => j.Id.ToString() == jobId);

            return result;
        }

        public async Task<JobAddFormModel> GetJobForEditByIdAsync(string jobId)
        {
            var job = await dbContext.Jobs
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
            var job = await dbContext.Jobs.FirstAsync(j => j.Id.ToString() == jobId);

            job.Title = model.Title;
            job.Description = model.Description;
            job.Requirements = model.Requirements;
            job.Salary = model.Salary;
            job.CategoryId = model.CategoryId;
            
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteJobByIdAsync(string jobId)
        {
            var job = await dbContext.Jobs.FindAsync(Guid.Parse(jobId));

            if (job != null)
            {
                dbContext.Jobs.Remove(job);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> CandidatureExistsAsync(string jobId, string candidateId)
        {
            var candidatureExists = await dbContext.UserJobs
                .AnyAsync(uj => uj.JobId.ToString() == jobId && uj.CandidateId.ToString() == candidateId);

            return candidatureExists;
        }

        public async Task<string> GetCvPathAsync(string jobId, string candidateId)
        {
            var candidature = await dbContext.UserJobs
                .FirstAsync(uj => uj.JobId.ToString() == jobId && uj.CandidateId.ToString() == candidateId);

            return candidature.FilePath;
        }

        public async Task<JobsFilteredAndPagedServiceModel> GetAllJobsAsync(JobsQueryModel queryModel)
        {
            var jobsQuery = dbContext.Jobs.AsQueryable();

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
                    CompanyAddress = j.Employer.CompanyAddress,
                    CreatedOn = j.CreatedOn
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
                CreatedOn = job.CreatedOn,
                EmployerInfo = new EmployerInfoViewModel()
                {
                    Name = job.Employer.User.FirstName + " " + job.Employer.User.LastName,
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
