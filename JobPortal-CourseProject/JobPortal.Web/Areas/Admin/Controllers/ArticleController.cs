namespace JobPortal.Web.Areas.Admin.Controllers
{
    using AspNetCoreHero.ToastNotification.Abstractions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Sevices.Data.Interfaces;
    using ViewModels.Article;

    public class ArticleController : BaseAdminController
    {
        private readonly IArticleService articleService;
        private readonly INotyfService toastNotification;

        public ArticleController(IArticleService articleService, INotyfService toastNotification)
        {
            this.articleService = articleService;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ArticleAddFormModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = User.GetId()!;
                var jobId = await articleService.CreateAndReturnIdAsync(userId, model);
                
                toastNotification.Success("Article was added successfully!");
                return RedirectToAction("Read", "Article", new { Area = "", id = jobId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new article! Please try again later or contact administrator!");
                return View(model);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> MyArticles()
        {
            var viewModel = await articleService.GetAllByAuthorIdAsync(User.GetId()!);
            
            return View(viewModel);
        }
    }
}