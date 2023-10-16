using BrightAkademi.Data.Concrete.EfCore.Configs;
using BrightAkademi.Entity.Concrete;
using BrightWeb.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Contexts
{
    public class BrightAkademiContext : DbContext
    {
        public BrightAkademiContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Level> Levels { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new LevelConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new CourseStudentConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new TeacherCourseConfig());

            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Category>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Company>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Teacher>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Level>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Course>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Student>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<UserRole>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsDeleted == false);
             
             

            base.OnModelCreating(modelBuilder);
        }
    }
}