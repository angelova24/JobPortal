namespace JobPortal.Sevices.Data.Interfaces
{
    using JobPortal.Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> GetAllCategoryNamesAsync();
    }
}
