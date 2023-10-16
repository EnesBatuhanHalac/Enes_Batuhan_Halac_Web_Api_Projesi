using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new UserRole
                {
                    Id = 1,
                    UserId= 1,
                    RoleId= 1,
                    IsActive = true,
                },        
                new UserRole
                {
                    Id = 2,
                    UserId = 2,
                    RoleId = 2,
                    IsActive = true,
                },   
                new UserRole
                {
                    Id = 3,
                    UserId = 3,
                    RoleId = 3,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 4,
                    UserId = 4,
                    RoleId = 3,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 5,
                    UserId = 5,
                    RoleId = 3,
                    IsActive = true,
                },                
                new UserRole
                {
                    Id = 6,
                    UserId = 6,
                    RoleId = 3,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 7,
                    UserId = 7,
                    RoleId = 3,
                    IsActive = true,
                },                                           
                new UserRole
                {
                    Id = 8,
                    UserId = 8,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 9,
                    UserId = 9,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 10,
                    UserId = 10,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 11,
                    UserId = 11,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 12,
                    UserId = 12,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 13,
                    UserId = 13,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 14,
                    UserId = 14,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 15,
                    UserId = 15,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 16,
                    UserId = 16,
                    RoleId = 4,
                    IsActive = true,
                },               
                new UserRole
                {
                    Id = 17,
                    UserId = 17,
                    RoleId = 4,
                    IsActive = true,
                }
               
            );
        }
    }
}