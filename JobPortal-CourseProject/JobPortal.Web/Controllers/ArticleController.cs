namespace JobPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sevices.Data.Interfaces;

    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var viewModel = await articleService.GetAllAsync();
            
            return View(viewModel);
        }
    }
}