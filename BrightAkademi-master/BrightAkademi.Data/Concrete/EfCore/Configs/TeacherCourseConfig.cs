using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class TeacherCourseConfig : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {

            builder.HasKey(cs => new { cs.CourseId, cs.TeacherId });

            builder.HasData(
                new TeacherCourse { CourseId = 1, TeacherId = 1 },
                new TeacherCourse { CourseId = 2, TeacherId = 1 },
                new TeacherCourse { CourseId = 3, TeacherId = 1 },
                new TeacherCourse { CourseId = 4, TeacherId = 2 },
                new TeacherCourse { CourseId = 5, TeacherId = 2 },
                new TeacherCourse { CourseId = 6, TeacherId = 2 },
                new TeacherCourse { CourseId = 7, TeacherId = 3 },
                new TeacherCourse { CourseId = 8, TeacherId = 3 },
                new TeacherCourse { CourseId = 9, TeacherId = 3 },
                new TeacherCourse { CourseId = 10, TeacherId = 4 },
                new TeacherCourse { CourseId = 11, TeacherId = 4 },
                new TeacherCourse { CourseId = 12, TeacherId = 4 },
                new TeacherCourse { CourseId = 13, TeacherId = 5 },
                new TeacherCourse { CourseId = 14, TeacherId = 5 },
                new TeacherCourse { CourseId = 15, TeacherId = 5 }
      
            );
        }
    }
}