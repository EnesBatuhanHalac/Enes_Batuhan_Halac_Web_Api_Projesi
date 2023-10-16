using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new User
                {
                    Id = 1,
                    Firstname = "EnesBatuhan",
                    Lastname = "Admin",
                    Username ="superadmin",
                    Password = "superadmin",
                    IsActive = true,
                },               
                new User
                {
                    Id = 2,
                    Firstname = "ilkercelik",
                    Lastname = "Admin",
                    Username ="admin",
                    Password = "admin",
                    IsActive = true,
                },
                 //Teachers
                 new User
                 {
                     Id = 3,
                     Firstname = "Ramiz",
                     Lastname = "Karaeski",
                     Username = "ramizkaraeski",
                     Password = "ramizkaraeski",
                     IsActive = true,
                 },
                new User
                {
                    Id = 4,
                    Firstname = "Kenan",
                    Lastname = "Birkan",
                    Username = "kenanbirkan",
                    Password = "kenanbirkan",
                    IsActive = true,
                },
                 new User
                 {
                     Id = 5,
                     Firstname = "Ezel",
                     Lastname = "Bayraktar",
                     Username = "ezelbayraktar",
                     Password = "ezelbayraktar",
                     IsActive = true,
                 },
                new User
                {
                    Id = 6,
                    Firstname = "Mehmet",
                    Lastname = "Tezcan",
                    Username = "mehmettezcan",
                    Password = "mehmettezcan",
                    IsActive = true,
                },
                new User
                {
                    Id = 7,
                    Firstname = "Selma",
                    Lastname = "Hünel",
                    Username = "selmahunel",
                    Password = "selmahunel",
                    IsActive = true,
                },
                //Students
                new User
                {
                    Id = 8,
                    Firstname = "Eyşan",
                    Lastname = "Atay",
                    Username = "eysanatay",
                    Password = "eysanatay",
                    IsActive = true,

                },
                 new User
                 {
                     Id = 9,
                     Firstname = "Ali",
                     Lastname = "Kırgız",
                     Username = "alikizgin",
                     Password = "alikizgin",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 10,
                     Firstname = "Teyfik",
                     Lastname = "Zaim",
                     Username = "teyfikzaim",
                     Password = "teyfikzaim",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 11,
                     Firstname = "JeremyRichard",
                     Lastname = "Figarland",
                     Username = "JeremyRichard",
                     Password = "figarlandFamily",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 12,
                     Firstname = "Cengiz",
                     Lastname = "Atay",
                     Username = "cengizatay",
                     Password = "cengizatay",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 13,
                     Firstname = "Samurai",
                     Lastname = "Jean",
                     Username = "samurai",
                     Password = "jean123Qwer.",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 14,
                     Firstname = "Şebnem",
                     Lastname = "Sertuna",
                     Username = "sebnemsertuna",
                     Password = "sebnemsertuna",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 15,
                     Firstname = "Temmuz",
                     Lastname = "Kocaoğlu",
                     Username = "temmuzkocaoglu",
                     Password = "temmuzkocaoglu",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 16,
                     Firstname = "Bahar",
                     Lastname = "Tezcan",
                     Username = "bahartezcan",
                     Password = "bahartezcan",
                     IsActive = true,

                 },
                 new User
                 {
                     Id = 17,
                     Firstname = "Azad",
                     Lastname = "Karaeski",
                     Username = "azadkaraeski",
                     Password = "azadkaraeski",
                     IsActive = true,

                 }
            );
        }
    } }