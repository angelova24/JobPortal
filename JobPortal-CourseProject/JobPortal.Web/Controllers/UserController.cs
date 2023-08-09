using AspNetCoreHero.ToastNotification.Abstractions;

namespace JobPortal.Web.Controllers
{
    using JobPortal.Sevices.Data.Interfaces;
    using Infrastructure.Extensions;
    using Data.Models;
    using ViewModels.User;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly IJobService jobService;
        private readonly IEmployerService employerService;
        private readonly INotyfService toastNotification;

        public UserController(SignInManager<ApplicationUser> signInManager,
                    UserManager<ApplicationUser> userManager,
                    IUserService userService,
                    IJobService jobService,
                    IEmployerService employerService,
                    INotyfService toastNotification)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
            this.jobService = jobService;
            this.employerService = employerService;
            this.toastNotification = toastNotification;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForJob(string id, IFormFile upload)
        {
            if (User.IsAdmin())
            {
                toastNotification.Error("As admin you are not allowed to apply for jobs!");
                
                return RedirectToAction("All", "Job");
            }
            
            var jobExists = await jobService.ExistsByIdAsync(id);
            
            if (!jobExists)
            {
                toastNotification.Error("Job with provided id does not exists! Please try again!");
                
                return RedirectToAction("All", "Job");
            }
            
            var userId = User.GetId()!;
            var alreadyApplied = await userService.HasAppliedForThatJobAsync(userId, id);
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(userId, id);
            
            if (alreadyApplied || isAuthorOfJob)
            {
                toastNotification.Error(alreadyApplied ? "You have already applied for that job!" : "You are the owner of that job!");
                return RedirectToAction("Index", "Home");
            }
            
            if (upload != null && upload.Length > 0)
            {
                if (upload.ContentType != "application/pdf")
                {
                    toastNotification.Error("Please upload a PDF file!");
                    return RedirectToAction("Details", "Job", new { id });
                }
                
                var fileName = Path.GetFileName(upload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CVs", fileName);
                
                try
                {
                    await userService.ApplyForJobAsync(userId, id, filePath);
                    await using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileStream);
                    }
                    toastNotification.Success("Successfully applied!");
                    return RedirectToAction("MyApplications", "User");
                }
                catch (Exception)
                {
                    GeneralError();
                }
            }
            
            toastNotification.Error("Please upload a file!");
            return RedirectToAction("Details", "Job", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> MyApplications()
        {
            var userId = User.GetId()!;

            var userApplicationJobs = await userService.GetAllJobsByCandidateIdAsync(userId);

            return View(userApplicationJobs);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result = 
                await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = 
                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                toastNotification.Error(
                    "There was an error while logging you in! Please try again later or contact an administrator.");

                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApplication(string id)
        {
            var jobExists = await jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                toastNotification.Error("Job with the provided id does not exist!");
                return RedirectToAction("MyApplications", "User");
            }

            var applicationExists = await userService.ApplicationExistsAsync(User.GetId()!, id);

            if (applicationExists)
            {
                try
                {
                    await userService.DeleteApplicationAsync(User.GetId()!, id);
                    toastNotification.Success("Application was successfully deleted!");
                    return RedirectToAction("MyApplications", "User");
                }
                catch (Exception)
                {
                    return GeneralError();
                }
            }
            
            toastNotification.Error("Application was not found!");
            return RedirectToAction("MyApplications", "User");
        }
        
        private IActionResult GeneralError()
        {
            toastNotification.Error("Unexpected error occurred! Please try again later or contact administrator");

            return RedirectToAction("Index", "Home");
        }
    }
}
