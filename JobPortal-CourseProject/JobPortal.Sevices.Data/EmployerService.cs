namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.ViewModels.Employer;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class EmployerService : IEmployerService
    {
        private readonly JobPortalDbContext dbContext;
        public EmployerService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(string userId, BecomeEmployerFormModel model)
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
    }
}
