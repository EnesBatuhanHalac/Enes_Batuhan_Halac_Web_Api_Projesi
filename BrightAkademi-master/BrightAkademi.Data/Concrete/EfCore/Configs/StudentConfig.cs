using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Student
                {
                    Id = 1,
                    UserId = 8,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 2,
                    UserId = 9,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 3,
                    UserId = 10,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 4,
                    UserId = 11,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 5,
                    UserId = 12,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 6,
                    UserId = 13,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 7,
                    UserId = 14,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 8,
                    UserId = 15,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 9,
                    UserId = 16,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                },
                new Student
                {
                    Id = 10,
                    UserId = 17,
                    EducationalStatus = "Kayıtlı öğrenci başlayacak."
                }
            );
        }
    }
}