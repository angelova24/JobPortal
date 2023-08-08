namespace JobPortal.Sevices.Data
{
    using Interfaces;
    using JobPortal.Data;
    using JobPortal.Data.Models;
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

        public async Task<string> CreateAndReturnIdAsync(string userId, ArticleAddFormModel model)
        {
            var newArticle = new Article()
            {
                Title = model.Title,
                Summary = model.Summary,
                Text = model.Text,
                AuthorId = Guid.Parse(userId)
            };

            await dbContext.Articles.AddAsync(newArticle);
            await dbContext.SaveChangesAsync();

            return newArticle.Id.ToString();
        }

        public async Task<ArticleAddFormModel> GetArticleForEditByIdAsync(string id)
        {
            var article = await dbContext.Articles
                .FirstAsync(a => a.Id.ToString() == id);

            return new ArticleAddFormModel
            {
                Title = article.Title,
                Summary = article.Summary,
                Text = article.Text
            };
        }

        public async Task EditArticleById(string id, ArticleAddFormModel model)
        {
            var article = await dbContext.Articles.FirstAsync(a => a.Id.ToString() == id);

            article.Title = model.Title;
            article.Summary = model.Summary;
            article.Text = model.Text;
            
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteArticleByIdAsync(string id)
        {
            var article = await dbContext.Articles.FindAsync(Guid.Parse(id));

            if (article != null)
            {
                dbContext.Articles.Remove(article);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}