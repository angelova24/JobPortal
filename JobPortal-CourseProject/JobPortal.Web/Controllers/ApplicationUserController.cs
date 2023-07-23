namespace JobPortal.Web.Controllers
{
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IJobService jobService;
        private readonly IEmployerService employerService;

        public ApplicationUserController(IApplicationUserService applicationUserService, IJobService jobService, IEmployerService employerService)
        {
            this.applicationUserService = applicationUserService;
            this.jobService = jobService;
            this.employerService = employerService;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForJob(string jobId)
        {
            var jobExists = await this.jobService.ExistsByIdAsync(jobId);

            if (!jobExists)
            {
                return BadRequest();
            }

            var userId = this.User.GetId()!;
            var alreadyApplied = await applicationUserService.HasAppliedForThatJobAsync(userId, jobId);
            var isAuthorOfJob = await employerService.IsAuthorOfJobAsync(userId, jobId);
            
            if (alreadyApplied || isAuthorOfJob)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await applicationUserService.ApplyForJobAsync(userId, jobId);
                return RedirectToAction("MyApplications", "ApplicationUser");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> MyApplications()
        {
            var userId = this.User.GetId()!;

            var userApplicationJobs = await applicationUserService.GetAllJobsByCandidateIdAsync(userId);

            return View(userApplicationJobs);
        }

    }
}
