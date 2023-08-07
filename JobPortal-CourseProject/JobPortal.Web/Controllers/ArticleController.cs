namespace JobPortal.Web.Controllers
{
    using AspNetCoreHero.ToastNotification.Abstractions;
    using Microsoft.AspNetCore.Mvc;
    using Sevices.Data.Interfaces;

    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly INotyfService toastNotification;

        public ArticleController(IArticleService articleService, INotyfService toastNotification)
        {
            this.articleService = articleService;
            this.toastNotification = toastNotification;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var viewModel = await articleService.GetAllAsync();
            
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Read(string id)
        {
            var articleExists = await articleService.ExistsByIdAsync(id);
            
            if (!articleExists)
            {
                toastNotification.Error("Article with the provided id does not exist!");
                return RedirectToAction("All", "Article");
            }
            
            var viewModel = await articleService.GetByIdAsync(id);
            
            return View(viewModel);
        }
    }
}