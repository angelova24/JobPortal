namespace JobPortal.Web.ViewModels.Article
{
    public class ArticleViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}