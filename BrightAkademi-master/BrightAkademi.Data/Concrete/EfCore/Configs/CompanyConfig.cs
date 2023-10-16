using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Wissen Akademie",
                    Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                    About = "Yazılım eğitimi veren ana kucağı",
                    PhoneNumber = "1234567890",
                    Email = "info.wissenakademie.com",
                    //FAQ = "Bilgim olmalı mı ? Eğitim durumum ne olmalı ?."
                }
            );
        }
    }
}
