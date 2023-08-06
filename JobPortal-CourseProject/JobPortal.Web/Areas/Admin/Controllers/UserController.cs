namespace JobPortal.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sevices.Data.Interfaces;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        public async Task<IActionResult> All()
        {
            var viewModel = await userService.GetAllAsync();
            
            return View(viewModel);
        }
    }
}