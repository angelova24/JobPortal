namespace JobPortal.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Sevices.Data.Interfaces;

    public class ArticleController : BaseAdminController
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> MyArticles()
        {
            var viewModel = await articleService.GetAllByAuthorIdAsync(User.GetId()!);
            
            return View(viewModel);
        }
    }
}