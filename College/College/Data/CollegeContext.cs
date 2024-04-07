using System;
using Microsoft.EntityFrameworkCore;
using College.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Metadata;

namespace College.Data
{
    public class CollegeContext : DbContext
    {
        public CollegeContext (DbContextOptions<CollegeContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Cohort> Cohort { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Exam> Exam { get; set; } = default!;
        public DbSet<Grade> Grade { get; set; } = default!;
        public DbSet<Faculty> Faculty { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
   }
