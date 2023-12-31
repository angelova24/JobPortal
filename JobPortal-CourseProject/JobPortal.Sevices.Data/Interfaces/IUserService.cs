﻿namespace JobPortal.Sevices.Data.Interfaces
{
    using Web.ViewModels.Job;
    using Web.ViewModels.User;

    public interface IUserService
    {
        Task ApplyForJobAsync(string userId, string jobId, string filePath);

        Task<bool> HasAppliedForThatJobAsync(string userId, string jobId);

        Task<IEnumerable<JobUserApplication>> GetAllJobsByCandidateIdAsync(string candidateId);
        
        Task<string> GetFullNameByEmailAsync(string email);
        
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        
        Task DeleteApplicationAsync(string userId, string jobId);
    }
}
