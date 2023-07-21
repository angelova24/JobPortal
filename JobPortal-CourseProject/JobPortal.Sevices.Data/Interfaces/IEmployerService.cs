namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Web.ViewModels.Employer;

    public interface IEmployerService
    {
        Task<bool> EmployerExistsByUserIdAsync(string userId);

        Task<bool> EmployerExistsByPhoneNumberAsync(string phoneNumber);

        Task CreateAsync(string userId, BecomeEmployerFormModel model);

        Task<string?> GetAgentIdByUserIdAsync(string userId);
    }
}
