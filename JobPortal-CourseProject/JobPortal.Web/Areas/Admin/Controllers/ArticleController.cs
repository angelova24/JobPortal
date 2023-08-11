namespace JobPortal.Web.Areas.Admin.Controllers
{
    using AspNetCoreHero.ToastNotification.Abstractions;
    using Hubs;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Sevices.Data.Interfaces;
    using ViewModels.Article;

    public class ArticleController : BaseAdminController
    {
        private readonly IArticleService articleService;
        private readonly INotyfService toastNotification;
        private readonly IHubContext<UpdateHub> hubContext;

        public ArticleController(IArticleService articleService,
            INotyfService toastNotification,
            IHubContext<UpdateHub> hubContext)
        {
            this.articleService = articleService;
            this.toastNotification = toastNotification;
            this.hubContext = hubContext;
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
                await hubContext.Clients.All.SendAsync("UpdateArticles");
                return RedirectToAction("Read", "Article", new { Area = "", id = jobId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new article! Please try again later or contact administrator!");
                return View(model);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var articleExists = await articleService.ExistsByIdAsync(id);

            if (!articleExists)
            {
                toastNotification.Error("Article with the provided id does not exist!");
                return RedirectToAction("All", "Article", new { Area = ""});
            }
            
            try
            {
                var model = await articleService.GetArticleForEditByIdAsync(id);
            
                return View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ArticleAddFormModel model)
        {
            var articleExists = await articleService.ExistsByIdAsync(id);

            if (!articleExists)
            {
                toastNotification.Error("Article with the provided id does not exist!");
                return RedirectToAction("All", "Article", new { Area = "" });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await articleService.EditArticleById(id, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
               
                return View(model);
            }
            
            toastNotification.Success("Article was edited successfully!");
            await hubContext.Clients.All.SendAsync("UpdateArticles");
            return RedirectToAction("Read", "Article", new { Area = "", id});
        }
        
        [HttpGet]
        public async Task<IActionResult> MyArticles()
        {
            var viewModel = await articleService.GetAllByAuthorIdAsync(User.GetId()!);
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var articleExists = await articleService.ExistsByIdAsync(id);

            if (!articleExists)
            {
                toastNotification.Error("Article with the provided id does not exist!");
                return RedirectToAction("All", "Article", new { Area = "" });
            }

            try
            {
                await articleService.DeleteArticleByIdAsync(id);
                toastNotification.Success("Article was deleted successfully!");
                await hubContext.Clients.All.SendAsync("UpdateArticles");
                return RedirectToAction("MyArticles", "Article");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
        
        private IActionResult GeneralError()
        {
            toastNotification.Error("Unexpected error occurred! Please try again later or contact administrator");

            return RedirectToAction("Index", "Home");
        }
    }
}