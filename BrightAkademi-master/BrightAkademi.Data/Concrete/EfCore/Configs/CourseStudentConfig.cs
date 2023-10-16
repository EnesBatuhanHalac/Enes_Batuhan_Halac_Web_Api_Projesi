using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Configs
{
    public class CourseStudentConfig : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {

            builder.HasKey(cs => new { cs.CourseId, cs.StudentId });

            builder.HasData(
                new CourseStudent { CourseId = 1, StudentId = 1 },
                new CourseStudent { CourseId = 1, StudentId = 2 },
                new CourseStudent { CourseId = 2, StudentId = 3 },
                new CourseStudent { CourseId = 2, StudentId = 4 },
                new CourseStudent { CourseId = 3, StudentId = 5 },
                new CourseStudent { CourseId = 3, StudentId = 6 },
                new CourseStudent { CourseId = 4, StudentId = 7 },
                new CourseStudent { CourseId = 4, StudentId = 8 },
                new CourseStudent { CourseId = 5, StudentId = 9 },
                new CourseStudent { CourseId = 5, StudentId = 10 },

                new CourseStudent { CourseId = 6, StudentId = 1 },
                new CourseStudent { CourseId = 6, StudentId = 2 },
                new CourseStudent { CourseId = 7, StudentId = 3 },
                new CourseStudent { CourseId = 7, StudentId = 4 },
                new CourseStudent { CourseId = 8, StudentId = 5 },
                new CourseStudent { CourseId = 8, StudentId = 6 },
                new CourseStudent { CourseId = 9, StudentId = 7 },
                new CourseStudent { CourseId = 9, StudentId = 8 },
                new CourseStudent { CourseId = 10, StudentId = 9 },
                new CourseStudent { CourseId = 10, StudentId = 10 },

                new CourseStudent { CourseId = 11, StudentId = 1 },
                new CourseStudent { CourseId = 11, StudentId = 2 },
                new CourseStudent { CourseId = 12, StudentId = 3 },
                new CourseStudent { CourseId = 12, StudentId = 4 },
                new CourseStudent { CourseId = 13, StudentId = 5 },
                new CourseStudent { CourseId = 13, StudentId = 6 },
                new CourseStudent { CourseId = 14, StudentId = 7 },
                new CourseStudent { CourseId = 14, StudentId = 8 },
                new CourseStudent { CourseId = 15, StudentId = 9 },
                new CourseStudent { CourseId = 15, StudentId = 10 }
            );
        }
    }
}