using College.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace College.DAL
{
    public class CollegeContext : DbContext
    {

        public CollegeContext() : base("CollegeContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}