using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class LevelConfig : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Level
                {
                    Id = 1,
                    Name = "Easy",
                },
                new Level
                {
                    Id = 2,
                    Name = "Medium",
                },
                new Level
                {
                    Id = 3,
                    Name = "Senior",
                }
            );
        }
    }
}