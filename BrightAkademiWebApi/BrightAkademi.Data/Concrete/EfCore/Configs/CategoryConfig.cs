using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Genel",
                    Description = "Kategorisi silinenleri buraya atacağız",
                    Url = "genel",
                },
                new Category
                {
                    Id = 2,
                    Name = "Full Stack Web Developer",
                    Description = "Full Stack Web Developer",
                    Url = "full-stack-web-developer",
                },
                new Category
                {
                    Id = 3,
                    Name = "IOS Developer",
                    Description = "IOS Developer",
                    Url = "ios-developer",
                },
                new Category
                {
                    Id = 4,
                    Name = "BackEnd Developer",
                    Description = "BackEnd Developer",
                    Url = "backend-developer",
                },
                new Category
                {
                    Id = 5,
                    Name = "FrontEnd Developer",
                    Description = "FrontEnd Developer",
                    Url = "frontend-developer",
                },
                new Category
                {
                    Id = 6,
                    Name = "Java Developer",
                    Description = "Java Developer",
                    Url = "java-developer",
                }
            );
        }
    }
}