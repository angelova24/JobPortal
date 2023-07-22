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

        public ApplicationUserController(IApplicationUserService applicationUserService, IJobService jobService)
        {
            this.applicationUserService = applicationUserService;
            this.jobService = jobService;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForJob(string jobId)
        {
            var jobExists = await this.jobService.ExistsByIdAsync(jobId);

            if (!jobExists)
            {
                return BadRequest();
            }

            var userId = this.User.GetId();
            var alreadyApplied = await applicationUserService.HasAppliedForThatJobAsync(userId!, jobId);
            
            if (alreadyApplied)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await applicationUserService.ApplyForJobAsync(userId!, jobId);
                return RedirectToAction("Mine", "Job");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}
