namespace JobPortal.Data.Configurations
{
    using JobPortal.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories() 
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;
            category = new Category()
            {
                Id = 1,
                Name = "IT"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Sales"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Finance"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Marketing and communication"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "HR"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
