namespace JobPortal.Services.Tests
{
    using JobPortal.Data;
    using Microsoft.EntityFrameworkCore;
    using Sevices.Data;
    using Web.ViewModels.Article;

    public class ArticleServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;
        private JobPortalDbContext dbContext;
        private ArticleService articleService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new JobPortalDbContext(dbOptions);
            
            dbContext.Database.EnsureCreated();
            articleService = new ArticleService(dbContext);
        }
        
        [Test]
        public async Task GetByIdAsyncShouldReturnArticleDetails()
        {
            var article = await dbContext.Articles.FirstAsync();
    
            var result = await articleService.GetByIdAsync(article.Id.ToString());

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(article.Id.ToString()));
                Assert.That(result.Title, Is.EqualTo(article.Title));
                Assert.That(result.Summary, Is.EqualTo(article.Summary));
                Assert.That(result.Text, Is.EqualTo(article.Text));
                Assert.That(result.CreatedOn, Is.EqualTo(article.CreatedOn));
                Assert.That(result.AuthorName, Is.EqualTo(article.Author.FirstName + " " + article.Author.LastName));
            });
        }
        
        [Test]
        public async Task ArticleExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            var existingArticle = await dbContext.Articles.FirstAsync();
        
            var result = await articleService.ExistsByIdAsync(existingArticle.Id.ToString());
        
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task ArticleExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            const string notExistingArticle = "74e320b2-3a2d-4407-a56e-7de3bc781f64";
        
            var result = await articleService.ExistsByIdAsync(notExistingArticle);
        
            Assert.That(result, Is.False);
        }
        
        [Test]
        public async Task CreateAndReturnIdAsyncShouldCreateArticleAndReturnId()
        {
            const string userId = "aa294071-5c7d-4f4c-8451-42fac506957c";
            var model = new ArticleAddFormModel()
            {
                Title = "Some Title",
                Summary = "Lorem ipsum dolor sit amet, consetetur sadipscing",
                Text = "Lorem ipsum dolor sit amet, consetetur sadipscing ",
            };

            var result = await articleService.CreateAndReturnIdAsync(userId, model);
            
            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task GetArticleForEditByIdAsyncShouldReturnArticleInfo()
        {
            var article = await dbContext.Articles.FirstAsync();

            var result = await articleService.GetArticleForEditByIdAsync(article.Id.ToString());
            
            Assert.Multiple(() =>
            {
                Assert.That(result.Title, Is.EqualTo(article.Title));
                Assert.That(result.Summary, Is.EqualTo(article.Summary));
                Assert.That(result.Text, Is.EqualTo(article.Text));
            });
        }
        
        [Test]
        public async Task EditArticleByIdAsyncShouldSetNewValues()
        {
            var article = await dbContext.Articles.FirstAsync();

            var model = new ArticleAddFormModel()
            {
                Title = "Some Title",
                Summary = "Lorem ipsum dolor sit amet, consetetur sadipscing",
                Text = "Lorem ipsum dolor sit amet, consetetur sadipscing "
            };
            
            await articleService.EditArticleById(article.Id.ToString(), model);
            
            Assert.Multiple(() =>
            {
                Assert.That(article.Title, Is.EqualTo(model.Title));
                Assert.That(article.Summary, Is.EqualTo(model.Summary));
                Assert.That(article.Text, Is.EqualTo(model.Text));
            });
        }
        
        [Test]
        public async Task DeleteArticleByIdAsyncShouldDeleteArticle()
        {
            var article = await dbContext.Articles.FirstAsync();

            await articleService.DeleteArticleByIdAsync(article.Id.ToString());
            
            var result = await dbContext.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);
            
            Assert.That(result, Is.Null);
        }
        
        [Test]
        public async Task GetAllAsyncShouldReturnArticles()
        {
            var result = await articleService.GetAllAsync();

            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task GetAllByAuthorIdAsyncShouldReturnArticles()
        {
            var article = await dbContext.Articles.FirstAsync();
            
            var result = await articleService.GetAllByAuthorIdAsync(article.AuthorId.ToString());

            Assert.That(result, Is.Not.Null);
        }
    }
}