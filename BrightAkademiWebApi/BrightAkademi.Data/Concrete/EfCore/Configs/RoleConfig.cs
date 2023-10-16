using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name="Super Admin",
                    IsActive = true,
                },        
                new Role
                {
                    Id = 2,
                    Name="Admin",
                    IsActive = true,
                },         
                new Role
                {
                    Id = 3,
                    Name= "Trainer",
                    IsActive = true,
                },        
                new Role
                {
                    Id = 4,
                    Name= "Trainee",
                    IsActive = true,
                }
               
            );
        }
    }
}