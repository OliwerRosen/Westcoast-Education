using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.ViewModels;

namespace education_api.Interfaces
{
  public interface IStudentCourseRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<StudentCourseViewModel>> ListAllStudentCoursesAsync();
    public Task<List<StudentCourseViewModel>> ListCoursesByStudentId(int studentId);
    public Task AddStudentCourseAsync(StudentCourseViewModel model);
    public Task<StudentCourseViewModel> EditStudentCourse(int studentId, int courseId);
    public Task<StudentCourseViewModel> DeleteStudentCourse(int studentId, int courseId);

  }

}