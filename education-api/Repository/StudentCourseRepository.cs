using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using education_api.Data;
using education_api.Interfaces;
using education_api.Model;
using education_api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace education_api.Repository
{
  public class StudentCourseRepository : IStudentCourseRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;

    public StudentCourseRepository(EducationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task AddStudentCourseAsync(StudentCourseViewModel model)
    {
      var studentToBind = await _context.Students
        .Where(c => c.Id == model.StudentId)
        .SingleOrDefaultAsync();

      var courseToBind = await _context.Courses
        .Where(s => s.CourseNr == model.CourseId)
        .SingleOrDefaultAsync();

      var studentCourse = new StudentCourse();
      studentCourse.CourseId = courseToBind!.CourseNr;
      studentCourse.Course = courseToBind!;
      studentCourse.StudentId = studentToBind!.Id;
      studentCourse.Student = studentToBind!;

      await _context.StudentCourses.AddAsync(studentCourse);
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<StudentCourseViewModel>> ListAllStudentCoursesAsync()
    {
      return await _context.StudentCourses.ProjectTo<StudentCourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }
    public async Task<List<StudentCourseViewModel>> ListCoursesByStudentId(int studentId)
    {
      throw new NotImplementedException();
    }
    //return await _context

    Task IStudentCourseRepository.AddStudentCourseAsync(StudentCourseViewModel model)
    {
      throw new NotImplementedException();
    }

    Task<StudentCourseViewModel> IStudentCourseRepository.EditStudentCourse(int studentId, int courseId)
    {
      throw new NotImplementedException();
    }

    Task<StudentCourseViewModel> IStudentCourseRepository.DeleteStudentCourse(int studentId, int courseId)
    {
      throw new NotImplementedException();
    }

    Task<bool> IStudentCourseRepository.SaveAllAsync()
    {
      throw new NotImplementedException();
    }

    Task<List<StudentCourseViewModel>> IStudentCourseRepository.ListAllStudentCoursesAsync()
    {
      throw new NotImplementedException();
    }


  }
}