namespace JobPortal.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : BaseAdminController
    {
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult MyArticles()
        {
            return View();
        }
    }
}