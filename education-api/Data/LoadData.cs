using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using education_api.Model;
using education_api.ViewModels;
using education_api.ViewModels.Teacher;
using education_api.ViewModels.TeacherSubject;
using Microsoft.EntityFrameworkCore;

namespace education_api.Data
{
  public class LoadData
  {
    public static async Task LoadCourses(EducationContext context)
    {
      if (await context.Courses.AnyAsync()) return;

      var courseData = await File.ReadAllTextAsync("Data/courses.json");
      var courses = JsonSerializer.Deserialize<List<PostCourseViewModel>>(courseData);

      if (courses is null) return;

      foreach (var course in courses)
      {
        var newCourse = new Course
        {
          CourseNr = course.CourseNr,
          CourseTitle = course.CourseTitle,
          Length = course.Length,
          Category = course.Category,
          Description = course.Description,
          Details = course.Details
        };
        context.Courses.Add(newCourse);
      }
    }
    public static async Task LoadTeachers(EducationContext context)
    {
      if (await context.Teachers.AnyAsync()) return;

      var teacherData = await File.ReadAllTextAsync("Data/teachers.json");
      var teachers = JsonSerializer.Deserialize<List<PostTeacherViewModel>>(teacherData);

      if (teachers is null) return;

      foreach (var teacher in teachers)
      {
        var newTeacher = new Teacher
        {
          Id = teacher.Id,
          FirstName = teacher.FirstName,
          LastName = teacher.LastName,
          Email = teacher.Email,
          PhoneNr = teacher.PhoneNr,
          Address = teacher.Address
        };
        context.Teachers.Add(newTeacher);
      }
    }
    public static async Task LoadStudents(EducationContext context)
    {
      if (await context.Students.AnyAsync()) return;

      var studentData = await File.ReadAllTextAsync("Data/students.json");
      var students = JsonSerializer.Deserialize<List<PostStudentViewModel>>(studentData);

      if (students is null) return;

      foreach (var student in students)
      {
        var newStudent = new Student
        {
          Id = student.Id,
          FirstName = student.FirstName,
          LastName = student.LastName,
          Email = student.Email,
          PhoneNr = student.PhoneNr,
          Address = student.Address
        };
        context.Students.Add(newStudent);
      }
    }
    public static async Task LoadSubjects(EducationContext context)
    {
      if (await context.Subjects.AnyAsync()) return;

      var subjectData = await File.ReadAllTextAsync("Data/subjects.json");
      var subjects = JsonSerializer.Deserialize<List<GetSubjectViewModel>>(subjectData);

      if (subjects is null) return;

      foreach (var subject in subjects)
      {
        var newSubject = new Subject
        {
          Id = subject.Id,
          Name = subject.Name
        };
        context.Subjects.Add(newSubject);
      }
    }
    public static async Task LoadTeacherSubjects(EducationContext context)
    {
      if (await context.TeacherSubjects.AnyAsync()) return;

      var subjectData = await File.ReadAllTextAsync("Data/teachersubjects.json");
      var teacherSubjects = JsonSerializer.Deserialize<List<GetTeacherSubjectViewModel>>(subjectData);

      if (teacherSubjects is null) return;

      foreach (var teacherSubject in teacherSubjects)
      {
        var newTeacherSubject = new TeacherSubject
        {
          TeacherId = teacherSubject.TeacherId,
          SubjectId = teacherSubject.SubjectId
        };
        context.TeacherSubjects.Add(newTeacherSubject);
      }
    }
  }
}