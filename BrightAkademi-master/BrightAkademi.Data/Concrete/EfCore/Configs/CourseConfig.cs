using BrightWeb.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            //builder.HasOne(course => course.Category)
            //.WithOne(category => category.Course)
            //.HasForeignKey<Course>(course => course.CategoryId)
            //.OnDelete(DeleteBehavior.SetNull);

            //builder.HasOne(course => course.Company)
            //.WithOne(category => category.Course)
            //.HasForeignKey<Course>(course => course.CompanyId)
            //.OnDelete(DeleteBehavior.SetNull);

            //builder.HasOne(course => course.Teacher)
            //.WithOne(category => category.Course)
            //.HasForeignKey<Course>(course => course.TeacherId)
            //.OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
               new Course
               {
                   Id = 1,
                   Name = "Full Stack Web Developer",
                   TotalCourseHours = "200",
                   HowManyMonths = "2",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Full Stack Developer eğitimi kapsamlı bir eğitim.",
                   Price = 10000,
                   Experience = "Bu eğitim sayesinde;Temel ve ileri veritabanı mantığını, Web’in ve yazılımın çalışma prensibini ve tüm süreçlerini, Yeni nesil tüm programlama araç ve dillerini, Back end programlamayı ve API yazmayı, Uçtan uca bir proje geliştirmeyi öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "html css bootstrap react react native c# .net javascript node.js ajax",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 2,
                   CompanyId = 1,
                   LevelId = 1,
                   TeacherId = 1
               },
               new Course
               {
                   Id = 2,
                   Name = "Full Stack Web Developer",
                   TotalCourseHours = "400",
                   HowManyMonths = "4",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Full Stack Developer eğitimi kapsamlı bir eğitim.",
                   Price = 10000,
                   Experience = "Bu eğitim sayesinde;Temel ve ileri veritabanı mantığını, Web’in ve yazılımın çalışma prensibini ve tüm süreçlerini, Yeni nesil tüm programlama araç ve dillerini, Back end programlamayı ve API yazmayı, Uçtan uca bir proje geliştirmeyi öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "html css bootstrap react react native c# .net javascript node.js ajax",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 2,
                   CompanyId = 1,
                   LevelId = 2,
                   TeacherId = 1
               },
               new Course
               {
                   Id = 3,
                   Name = "Full Stack Web Developer",
                   TotalCourseHours = "600",
                   HowManyMonths = "6",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Full Stack Developer eğitimi kapsamlı bir eğitim.",
                   Price = 10000,
                   Experience = "Bu eğitim sayesinde;Temel ve ileri veritabanı mantığını, Web’in ve yazılımın çalışma prensibini ve tüm süreçlerini, Yeni nesil tüm programlama araç ve dillerini, Back end programlamayı ve API yazmayı, Uçtan uca bir proje geliştirmeyi öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "html css bootstrap react react native c# .net javascript node.js ajax",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 2,
                   CompanyId = 1,
                   LevelId = 3,
                   TeacherId = 1
               },
               new Course
               {
                   Id = 4,
                   Name = "IOS Developer",
                   TotalCourseHours = "100",
                   HowManyMonths = "1",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "IOS Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde IOS Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak swift programını öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "Swift",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 3,
                   CompanyId = 1,
                   LevelId = 1,
                   TeacherId = 2
               },
               new Course
               {
                   Id = 5,
                   Name = "IOS Developer",
                   TotalCourseHours = "200",
                   HowManyMonths = "2",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "IOS Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde IOS Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak swift programını öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "Swift",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 3,
                   CompanyId = 1,
                   LevelId = 2,
                   TeacherId = 2
               },
               new Course
               {
                   Id = 6,
                   Name = "IOS Developer",
                   TotalCourseHours = "300",
                   HowManyMonths = "3",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "IOS Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde IOS Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak swift programını öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "Swift",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 3,
                   CompanyId = 1,
                   LevelId = 3,
                   TeacherId = 2
               },
               new Course
               {
                   Id = 7,
                   Name = "Backend Developer",
                   TotalCourseHours = "100",
                   HowManyMonths = "1",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Backend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Backend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "c# .net javascript node.js ajax ",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 4,
                   CompanyId = 1,
                   LevelId = 1,
                   TeacherId = 3
               },
               new Course
               {
                   Id = 8,
                   Name = "Backend Developer",
                   TotalCourseHours = "200",
                   HowManyMonths = "2",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Backend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Backend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "c# .net javascript node.js ajax ",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 4,
                   CompanyId = 1,
                   LevelId = 2,
                   TeacherId = 3
               },
               new Course
               {
                   Id = 9,
                   Name = "Backend Developer",
                   TotalCourseHours = "300",
                   HowManyMonths = "3",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Backend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Backend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "c# .net javascript node.js ajax ",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 4,
                   CompanyId = 1,
                   LevelId = 3,
                   TeacherId = 3
               },
               new Course
               {
                   Id = 10,
                   Name = "Frontend Developer",
                   TotalCourseHours = "100",
                   HowManyMonths = "1",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Frontend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Frontend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "html css bootstrap javascript react react native",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 5,
                   CompanyId = 1,
                   LevelId = 1,
                   TeacherId = 4
               },
               new Course
               {
                   Id = 11,
                   Name = "Frontend Developer",
                   TotalCourseHours = "200",
                   HowManyMonths = "2",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Frontend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Frontend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "html css bootstrap javascript react react native",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 5,
                   CompanyId = 1,
                   LevelId = 2,
                   TeacherId = 4
               },
               new Course
               {
                   Id = 12,
                   Name = "Frontend Developer",
                   TotalCourseHours = "300",
                   HowManyMonths = "3",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Frontend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Frontend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "html css bootstrap javascript react react native",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 5,
                   CompanyId = 1,
                   LevelId = 3,
                   TeacherId = 4
               },
               new Course
               {
                   Id = 13,
                   Name = "Java Developer",
                   TotalCourseHours = "100",
                   HowManyMonths = "1",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Frontend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Java Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "Java",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 6,
                   CompanyId = 1,
                   LevelId = 1,
                   TeacherId = 5
               },
               new Course
               {
                   Id = 14,
                   Name = "Java Developer",
                   TotalCourseHours = "200",
                   HowManyMonths = "2",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Frontend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Java Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "Java",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 6,
                   CompanyId = 1,
                   LevelId = 2,
                   TeacherId = 5
               },
               new Course
               {
                   Id = 15,
                   Name = "Java Developer",
                   TotalCourseHours = "300",
                   HowManyMonths = "3",
                   StartCourseTime = new DateTime(2024, 1, 1),
                   FinishCourseTime = new DateTime(2024, 7, 1),
                   Description = "Frontend Developer",
                   Price = 10000,
                   Experience = "Bu eğitimde Java Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.",
                   Address = "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul",
                   Content = "Java",
                   Comment = "Çok iyi bir kurs 10 puan",
                   Status = "Açılacak",
                   IsActive = false,

                   CategoryId = 6,
                   CompanyId = 1,
                   LevelId = 3,
                   TeacherId = 5
               }
           );
        }
    }
}
