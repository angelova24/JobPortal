namespace JobPortal.Web.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Article;
    
    public class ArticleAddFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(SummaryMaxLenght, MinimumLength = SummaryMinLenght)]
        public string Summary { get; set; } = null!;

        [Required]
        [StringLength(TextMaxLenght, MinimumLength = TextMinLenght)]
        public string Text { get; set; } = null!;
    }
}