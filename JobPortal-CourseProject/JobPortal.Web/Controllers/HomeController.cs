namespace JobPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static Common.GeneralApplicationConstants;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            return statusCode switch
            {
                404 => View("Error404"),
                401 => View("Error401"),
                _ => View()
            };
        }
    }
}