using GradeSystem.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GradeSystem.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext() : base("SystemContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>().HasMany(c => c.Teachers).WithMany(t => t.Courses).Map(i => i.MapLeftKey("CourseID").MapRightKey("TeacherID").ToTable("CourseTeacher"));
        }
    }
}