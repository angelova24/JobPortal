namespace JobPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    public class ArticleController : Controller
    {
        
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }
    }
}