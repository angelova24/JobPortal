namespace JobPortal.Services.Tests
{
    using JobPortal.Data;
    using Microsoft.EntityFrameworkCore;
    using Sevices.Data;

    public class CategoryServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;
        private JobPortalDbContext dbContext;
        private CategoryService categoryService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new JobPortalDbContext(dbOptions);
            
            dbContext.Database.EnsureCreated();
            categoryService = new CategoryService(dbContext);
        }
        
        [Test]
        public async Task CategoryExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            var existingCategory = await dbContext.Categories.FirstAsync();
        
            var result = await categoryService.ExistsByIdAsync(existingCategory.Id);
        
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task CategoryExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            const int notExistingCategory = 155;
        
            var result = await categoryService.ExistsByIdAsync(notExistingCategory);
        
            Assert.That(result, Is.False);
        }
        
        [Test]
        public async Task GetAllAsyncShouldReturnCategories()
        {
            var result = await categoryService.GetAllAsync();

            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task GetCategoryNamesShouldReturnCategories()
        {
            var result = await categoryService.GetAllCategoryNamesAsync();

            Assert.That(result, Is.Not.Null);
        }
    }
}