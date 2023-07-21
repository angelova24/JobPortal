namespace JobPortal.Sevices.Data
{
    using JobPortal.Data;
    using JobPortal.Sevices.Data.Interfaces;
    using JobPortal.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly JobPortalDbContext dbContext;

        public CategoryService(JobPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            var result = await this.dbContext.Categories.AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var allCategories = await this.dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return allCategories;
        }
    }
}
