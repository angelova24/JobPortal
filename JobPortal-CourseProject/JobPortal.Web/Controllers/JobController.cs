using AspNetCoreHero.ToastNotification.Abstractions;

namespace JobPortal.Web.Controllers
{
    using JobPortal.Sevices.Data.Interfaces;
    using Infrastructure.Extensions;
    using ViewModels.Job;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        private readonly ICategoryService categoryService;
        private readonly IEmployerService employerService;
        private readonly INotyfService toastNotification;

        public JobController(IJobService jobService, ICategoryService categoryService, IEmployerService employerService, INotyfService toastNotification)
        {
            this.jobService = jobService;
            this.categoryService = categoryService;
            this.employerService = employerService;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]JobsQueryModel queryModel)
        {
            try
            {
                var serviceModel = await jobService.GetAllJobsAsync(queryModel);

                queryModel.Jobs = serviceModel.Jobs;
                queryModel.TotalJobs = serviceModel.JobsCount;
                queryModel.Categories = await categoryService.GetAllCategoryNamesAsync();

                return View(queryModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var isEmployer = await employerService.EmployerExistsByUserIdAsync(User.GetId()!);

            if (!isEmployer)
            {
                toastNotification.Error("You must be an employer in order to add new job!");
                return RedirectToAction("Become", "Employer");
            }

            try
            {
                var formModel = new JobAddFormModel()
                {
                    Categories = await categoryService.GetAllAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobAddFormModel model)
        {
            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(User.GetId()!);

            if (!isUserEmployer)
            {
                toastNotification.Error("You must be an employer in order to add new job!");
                return RedirectToAction("Become", "Employer");
            }

            var categoryExists = await categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist.");
            }

            if(!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllAsync();
                return View(model);
            }

            try
            {
                var employerId = await employerService.GetEmployerIdByUserIdAsync(User.GetId()!);
                string jobId = await jobService.CreateAndReturnIdAsync(employerId!, model);
                
                toastNotification.Success("Job was added successfully!");
                return RedirectToAction("Details", "Job", new { id = jobId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new job! Please try again later or contact administrator!");
                model.Categories = await categoryService.GetAllAsync();

                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var jobExists = await jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                toastNotification.Error("Job with the provided id does not exist!");
                return RedirectToAction("All", "Job");
            }

            try
            {
                var model = await jobService.GetJobDetailsByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var jobExists = await jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                toastNotification.Error("Job with the provided id does not exist!");
                return RedirectToAction("All", "Job");
            }

            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(User.GetId()!);

            if (!isUserEmployer && !User.IsAdmin())
            {
                toastNotification.Error("You must be an employer in order to edit job info!");
                return RedirectToAction("Become", "Employer");
            }
            
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(User.GetId()!, id);

            if (!isAuthorOfJob && !User.IsAdmin())
            {
                toastNotification.Error("You must be the author of the job you want to edit!");
                return RedirectToAction("MyJobOffers", "Employer");
            }

            try
            {
                var model = await jobService.GetJobForEditByIdAsync(id);
                model.Categories = await categoryService.GetAllAsync();
            
                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, JobAddFormModel model)
        {
            var jobExists = await jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                toastNotification.Error("Job with the provided id does not exist!");
                return RedirectToAction("All", "Job");
            }
            
            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(User.GetId()!);

            if (!isUserEmployer && !User.IsAdmin())
            {
                toastNotification.Error("You must be an employer in order to edit job info!");
                return RedirectToAction("Become", "Employer");
            }
            
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(User.GetId()!, id);

            if (!isAuthorOfJob && !User.IsAdmin())
            {
                toastNotification.Error("You must be the author of the job you want to edit!");
                return RedirectToAction("MyJobOffers", "Employer");
            }
            
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllAsync();
                return View(model);
            }

            try
            {
                await jobService.EditJobById(id, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
               
                model.Categories = await categoryService.GetAllAsync();
                return View(model);
            }
            
            toastNotification.Success("Job was edited successfully!");
            return RedirectToAction("Details", "Job", new {id});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var jobExists = await jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                toastNotification.Error("Job with the provided id does not exist!");
                return RedirectToAction("All", "Job");
            }
            
            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(User.GetId()!);

            if (!isUserEmployer && !User.IsAdmin())
            {
                toastNotification.Error("You must be an employer in order to delete the job!");
                return RedirectToAction("Become", "Employer");
            }
            
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(User.GetId()!, id);

            if (!isAuthorOfJob && !User.IsAdmin())
            {
                toastNotification.Error("You must be the author of the job you want to delete!");
                return RedirectToAction("MyJobOffers", "Employer");
            }

            try
            {
                await jobService.DeleteJobByIdAsync(id);
                toastNotification.Success("Job was deleted successfully!");
                return RedirectToAction("MyJobOffers", "Employer");
            }
            catch (Exception)
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
