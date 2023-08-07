using AspNetCoreHero.ToastNotification.Abstractions;

namespace JobPortal.Web.Controllers
{
    using JobPortal.Sevices.Data.Interfaces;
    using Infrastructure.Extensions;
    using ViewModels.Employer;
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
            var userId = User.GetId()!;

            try
            {
                var isEmployer = await employerService.EmployerExistsByUserIdAsync(userId);

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
            var userId = User.GetId()!;
            var isEmployer = await employerService.EmployerExistsByUserIdAsync(userId);

            if (isEmployer)
            {
                toastNotification.Error("You are already an employer!");
                return RedirectToAction("Index", "Home");
            }

            var isPhoneNumberTaken =
                await employerService.EmployerExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Employer with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await employerService.CreateAsync(userId, model);
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
            var userId = User.GetId()!;
            var isEmployer = await employerService.EmployerExistsByUserIdAsync(userId);

            if (!isEmployer)
            {
                toastNotification.Error("You must be an employer!");
                return RedirectToAction("Become", "Employer");
            }

            try
            {
                var employerId = await employerService.GetEmployerIdByUserIdAsync(userId);
                var jobOffers = await employerService.GetAllJobsByEmployerIdAsync(employerId!);

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
