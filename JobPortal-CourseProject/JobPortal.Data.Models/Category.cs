namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            Jobs = new HashSet<Job>();       
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}