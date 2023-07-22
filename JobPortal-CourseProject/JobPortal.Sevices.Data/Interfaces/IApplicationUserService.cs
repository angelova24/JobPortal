namespace JobPortal.Sevices.Data.Interfaces
{
    public interface IApplicationUserService
    {
        Task ApplyForJobAsync(string userId, string jobId);

        Task<bool> HasAppliedForThatJobAsync(string userId, string jobId);
    }
}
