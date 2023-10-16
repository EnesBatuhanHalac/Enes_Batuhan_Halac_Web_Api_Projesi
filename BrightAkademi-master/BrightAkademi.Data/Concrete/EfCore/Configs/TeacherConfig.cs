using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Teacher
                {
                    Id = 1,
                    UserId = 3,
                    Profession = "Full Stack Web Developer",
                    Experience = "30",
                    EducationInfo = "Zonguldak Bilgisayar Öğretmenliği",
                    Comment = "10 puan",
                    IsActive = true,
                },
                new Teacher
                {
                    Id = 2,
                    UserId = 4,
                    Profession = "IOS Developer",
                    Experience = "10",
                    EducationInfo = "Eskişehir Bilgisayar Mühendisliği",
                    Comment = "10 puan",
                    IsActive = true,
                },
                new Teacher
                {
                    Id = 3,
                    UserId = 5,
                    Profession = "Backend Developer",
                    Experience = "2",
                    EducationInfo = "Bahçeşehir Üniversitesi Yazılım Mühendisliği",
                    Comment = "10 puan",
                    IsActive = true,
                },
                new Teacher
                {
                    Id = 4,
                    UserId = 6,
                    Profession = "Frontend Developer",
                    Experience = "2",
                    EducationInfo = "Arel Üniversitesi Elektronik Haberleşme Mühendisliği",
                    Comment = "10 puan",
                    IsActive = true,
                },
                new Teacher
                {
                    Id = 5,
                    UserId = 7,
                    Profession = "Java Developer",
                    Experience = "2",
                    EducationInfo = "Doğuş Üniversitesi",
                    Comment = "10 puan",
                    IsActive = true,
                }
            );
        }
    }
}