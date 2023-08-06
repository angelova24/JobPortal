namespace JobPortal.Sevices.Data
{
    using Interfaces;
    using JobPortal.Data;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Article;

    public class ArticleService : IArticleService
    {
        private readonly JobPortalDbContext dbContext;

        public ArticleService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<IEnumerable<ArticleViewModel>> GetAllAsync()
        {
            var articles = await dbContext.Articles
                .Select(a => new ArticleViewModel()
                {
                    Id = a.Id.ToString(),
                    Title = a.Title,
                    Summary = a.Summary
                })
                .ToListAsync();

            return articles;
        }
    }
}