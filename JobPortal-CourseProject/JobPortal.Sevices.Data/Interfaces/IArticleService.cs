namespace JobPortal.Sevices.Data.Interfaces
{
    using Web.ViewModels.Article;

    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> GetAllAsync();
        
        Task<ArticleDetailsViewModel> GetByIdAsync(string id);
        
        Task<bool> ExistsByIdAsync(string id);
        
        Task<IEnumerable<ArticleViewModel>> GetAllByAuthorIdAsync(string id);
    }
}