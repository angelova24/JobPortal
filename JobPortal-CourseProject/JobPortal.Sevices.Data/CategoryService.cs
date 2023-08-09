namespace JobPortal.Sevices.Data
{
    using Interfaces;
    using JobPortal.Data;
    using Microsoft.EntityFrameworkCore;
    using Web.ViewModels.Category;

    public class CategoryService : ICategoryService
    {
        private readonly JobPortalDbContext dbContext;

        public CategoryService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            var result = await dbContext.Categories.AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var allCategories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return allCategories;
        }

        public async Task<IEnumerable<string>> GetAllCategoryNamesAsync()
        {
            var allNames = await dbContext.Categories.Select(c => c.Name).ToListAsync();

            return allNames;
        }
    }
}
