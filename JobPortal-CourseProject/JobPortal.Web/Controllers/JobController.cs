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
                var employerId = await this.employerService.GetAgentIdByUserIdAsync(this.User.GetId()!);
                await this.jobService.CreateAsync(employerId!, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new job! Please try again later or contact administrator!");
                model.Categories = await categoryService.GetAllAsync();

                return View(model);
            }

            return RedirectToAction("All", "Job");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var model = await jobService.GetJobByIdAsync(id);

            if (model == null)
            {
                return RedirectToAction("All", "Job");
            }

            return View(model);
        }
    }
}
