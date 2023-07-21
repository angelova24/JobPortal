namespace JobPortal.Web.Controllers
{
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.Infrastructure.Extensions;
    using JobPortal.Web.ViewModels.Employer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class EmployerController : Controller
    {
        private readonly IEmployerService employerService;

        public EmployerController(IEmployerService employerService)
        {
            this.employerService = employerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var userId = this.User.GetId();
            var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(userId);

            if (isEmployer)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeEmployerFormModel model)
        {
            var userId = this.User.GetId();
            var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(userId);

            if (isEmployer)
            {
                return RedirectToAction("Index", "Home");
            }

            var isPhoneNumberTaken =
                await this.employerService.EmployerExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Employer with the provided phone number already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.employerService.Create(userId, model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("All", "Job");
        }
    }
}
