using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.Model;
using Microsoft.EntityFrameworkCore;

namespace education_api.Data
{
  public class EducationContext : DbContext
  {
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<TeacherSubject> TeacherSubjects => Set<TeacherSubject>();

    public EducationContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<StudentCourse>()
        .HasKey(sc => new { sc.Id });
      modelBuilder.Entity<StudentCourse>()
        .HasOne(s => s.Student)
        .WithMany(sc => sc.StudentCourses)
        .HasForeignKey(sc => sc.StudentId);
      modelBuilder.Entity<StudentCourse>()
        .HasOne(c => c.Course)
        .WithMany(sc => sc.StudentCourses)
        .HasForeignKey(sc => sc.CourseId);

      modelBuilder.Entity<TeacherSubject>()
        .HasKey(ts => new { ts.Id });
      modelBuilder.Entity<TeacherSubject>()
        .HasOne(t => t.Teacher)
        .WithMany(ts => ts.TeacherSubjects)
        .HasForeignKey(ts => ts.TeacherId);
      modelBuilder.Entity<TeacherSubject>()
        .HasOne(s => s.Subject)
        .WithMany(ts => ts.TeacherSubjects)
        .HasForeignKey(ts => ts.SubjectId);

    }
  }
}