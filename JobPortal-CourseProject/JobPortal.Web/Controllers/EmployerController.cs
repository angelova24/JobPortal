using AspNetCoreHero.ToastNotification.Abstractions;

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
        private readonly INotyfService toastNotification;

        public EmployerController(IEmployerService employerService, INotyfService toastNotification)
        {
            this.employerService = employerService;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var userId = this.User.GetId()!;

            try
            {
                var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(userId);

                if (isEmployer)
                {
                    toastNotification.Error("You are already an employer!");
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeEmployerFormModel model)
        {
            var userId = this.User.GetId()!;
            var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(userId);

            if (isEmployer)
            {
                toastNotification.Error("You are already an employer!");
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
                await this.employerService.CreateAsync(userId, model);
            }
            catch (Exception)
            {
                return GeneralError();
            }

            toastNotification.Success("You have successfully registered as an employer!");
            return RedirectToAction("All", "Job");
        }

        [HttpGet]
        public async Task<IActionResult> MyJobOffers()
        {
            var userId = this.User.GetId()!;
            var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(userId);

            if (!isEmployer)
            {
                toastNotification.Error("You must be an employer!");
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var employerId = await this.employerService.GetEmployerIdByUserIdAsync(userId);
                var jobOffers = await this.employerService.GetAllJobsByEmployerIdAsync(employerId!);

                return View(jobOffers);
            }
            catch (Exception )
            {
                return GeneralError();
            }
        }
        
        private IActionResult GeneralError()
        {
            toastNotification.Error("Unexpected error occurred! Please try again later or contact administrator");

            return RedirectToAction("Index", "Home");
        }
    }
}
