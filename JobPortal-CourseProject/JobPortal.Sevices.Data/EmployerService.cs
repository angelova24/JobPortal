namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.ViewModels.Employer;
    using JobPortal.Web.ViewModels.Job;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

            await this.dbContext.AddAsync(newEmployer);
            await this.dbContext.SaveChangesAsync();
        }


        public async Task<bool> EmployerExistsByPhoneNumberAsync(string phoneNumber)
        {
            var result = await this.dbContext.Employers.AnyAsync(e => e.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> EmployerExistsByUserIdAsync(string userId)
        {
            var result = await this.dbContext.Employers.AnyAsync(e => e.UserId.ToString() == userId);

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
                    CompanyAddress = j.Employer.CompanyAddress
                })
                .ToListAsync();

            return allEmployerJobs;
        }
    }
}
