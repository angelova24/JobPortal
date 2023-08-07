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
                    Summary = a.Summary,
                    CreatedOn = a.CreatedOn
                })
                .OrderByDescending(a => a.CreatedOn)
                .ToListAsync();

            return articles;
        }

        public async Task<ArticleDetailsViewModel> GetByIdAsync(string id)
        {
            var article = await dbContext.Articles
                .Include(a => a.Author)
                .FirstAsync(a => a.Id.ToString() == id);

            var articleModel = new ArticleDetailsViewModel()
            {
                Id = article.Id.ToString(),
                Title = article.Title,
                Summary = article.Summary,
                Text = article.Text,
                CreatedOn = article.CreatedOn,
                AuthorName = article.Author.FirstName + " " + article.Author.LastName
            };

            return articleModel;
        }

        public async Task<bool> ExistsByIdAsync(string id)
        {
            var article = await dbContext.Articles.FirstOrDefaultAsync(a => a.Id.ToString() == id);

            if (article == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<ArticleViewModel>> GetAllByAuthorIdAsync(string id)
        {
            var articles = await dbContext.Articles
                .Where(a => a.AuthorId.ToString() == id)
                .Select(a => new ArticleViewModel()
                {
                    Id = a.Id.ToString(),
                    Title = a.Title,
                    Summary = a.Summary,
                    CreatedOn = a.CreatedOn
                })
                .OrderByDescending(a => a.CreatedOn)
                .ToListAsync();

            return articles;
        }
    }
}