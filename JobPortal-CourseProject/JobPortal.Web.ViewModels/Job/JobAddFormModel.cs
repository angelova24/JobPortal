namespace JobPortal.Web.ViewModels.Job
{
    using System.ComponentModel.DataAnnotations;
    using Category;
    using static Common.EntityValidationConstants.Job;
    
    public class JobAddFormModel
    {
        public JobAddFormModel()
        {
            Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(RequirementsMaxLenght, MinimumLength = RequirementsMinLenght)]
        public string Requirements { get; set; } = null!;

        [Display(Name = "Salary per month")]
        public int? Salary { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
