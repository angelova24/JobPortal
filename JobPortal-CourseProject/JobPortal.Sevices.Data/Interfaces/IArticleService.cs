namespace JobPortal.Sevices.Data.Interfaces
{
    using Web.ViewModels.Article;

    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> GetAllAsync();
        
        Task<ArticleDetailsViewModel> GetByIdAsync(string id);
        
        Task<bool> ExistsByIdAsync(string id);
        
        Task<IEnumerable<ArticleViewModel>> GetAllByAuthorIdAsync(string id);
        
        Task<string> CreateAndReturnIdAsync(string userId, ArticleAddFormModel model);
        
        Task<ArticleAddFormModel> GetArticleForEditByIdAsync(string id);
        
        Task EditArticleById(string id, ArticleAddFormModel model);
        
        Task DeleteArticleByIdAsync(string id);
    }
}