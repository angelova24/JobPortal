using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Areas.Admin.Controllers;

public class HomeController : BaseAdminController
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}