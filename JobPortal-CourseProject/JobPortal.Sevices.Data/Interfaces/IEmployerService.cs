namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Web.ViewModels.Employer;

    public interface IEmployerService
    {
        Task<bool> EmployerExistsByUserIdAsync(string userId);

        Task<bool> EmployerExistsByPhoneNumberAsync(string phoneNumber);

        Task Create(string userId, BecomeEmployerFormModel model);
    }
}
