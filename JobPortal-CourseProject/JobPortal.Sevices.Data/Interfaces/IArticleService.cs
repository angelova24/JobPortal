namespace JobPortal.Sevices.Data.Interfaces
{
    using Web.ViewModels.Article;

    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> GetAllAsync();
    }
}