namespace JobPortal.Web.Controllers
{
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.Infrastructure.Extensions;
    using JobPortal.Web.ViewModels.Job;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        private readonly ICategoryService categoryService;
        private readonly IEmployerService employerService;

        public JobController(IJobService jobService, ICategoryService categoryService, IEmployerService employerService)
        {
            this.jobService = jobService;
            this.categoryService = categoryService;
            this.employerService = employerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]JobsQueryModel queryModel)
        {
            var serviceModel = await this.jobService.GetAllJobsAsync(queryModel);

            queryModel.Jobs = serviceModel.Jobs;
            queryModel.TotalJobs = serviceModel.JobsCount;
            queryModel.Categories = await this.categoryService.GetAllCategoryNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(this.User.GetId()!);

            if (!isEmployer)
            {
                return RedirectToAction("Become", "Employer");
            }

            var formModel = new JobAddFormModel()
            {
                Categories = await this.categoryService.GetAllAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobAddFormModel model)
        {
            var isEmployer = await this.employerService.EmployerExistsByUserIdAsync(this.User.GetId()!);

            if (!isEmployer)
            {
                return RedirectToAction("Become", "Employer");
            }

            var categoryExists = await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist.");
            }

            if(!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.GetAllAsync();
                return View(model);
            }

            try
            {
                var employerId = await this.employerService.GetEmployerIdByUserIdAsync(this.User.GetId()!);
                string jobId = await this.jobService.CreateAndReturnIdAsync(employerId!, model);
                
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
            var jobExists = await this.jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                return RedirectToAction("All", "Job");
            }
            
            var model = await this.jobService.GetJobDetailsByIdAsync(id);

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var jobExists = await this.jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                return RedirectToAction("All", "Job");
            }

            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserEmployer)
            {
                return RedirectToAction("Become", "Employer");
            }
            
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(this.User.GetId()!, id);

            if (!isAuthorOfJob)
            {
                return RedirectToAction("MyJobOffers", "Employer");
            }

            var model = await this.jobService.GetJobForEditByIdAsync(id);
            model.Categories = await this.categoryService.GetAllAsync();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, JobAddFormModel model)
        {
            var jobExists = await this.jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                return RedirectToAction("All", "Job");
            }
            
            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserEmployer)
            {
                return RedirectToAction("Become", "Employer");
            }
            
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(this.User.GetId()!, id);

            if (!isAuthorOfJob)
            {
                return RedirectToAction("MyJobOffers", "Employer");
            }
            
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.GetAllAsync();
                return this.View(model);
            }

            try
            {
                await this.jobService.EditJobById(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
               
                model.Categories = await this.categoryService.GetAllAsync();
                return this.View(model);
            }

            return RedirectToAction("Details", "Job", new {id});
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var jobExists = await this.jobService.ExistsByIdAsync(id);

            if (!jobExists)
            {
                return RedirectToAction("All", "Job");
            }
            
            var isUserEmployer = await employerService.EmployerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserEmployer)
            {
                return RedirectToAction("Become", "Employer");
            }
            
            var isAuthorOfJob = await employerService.IsAuthorOfJobByUserIdAsync(this.User.GetId()!, id);

            if (!isAuthorOfJob)
            {
                return RedirectToAction("MyJobOffers", "Employer");
            }

            try
            {
                await this.jobService.DeleteJobByIdAsync(id);
                return RedirectToAction("MyJobOffers", "Employer");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
