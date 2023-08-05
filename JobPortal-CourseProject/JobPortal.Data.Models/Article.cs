namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Article;

    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(SummaryMaxLenght, MinimumLength = SummaryMinLenght)]
        public string Summary { get; set; } = null!;

        [Required]
        [StringLength(TextMaxLenght, MinimumLength = TextMinLenght)]
        public string Text { get; set; } = null!;

        public Guid AuthorId { get; set; }
        
        public virtual ApplicationUser Author { get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}