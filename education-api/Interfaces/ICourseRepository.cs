using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.ViewModels;
using education_api.ViewModels.Course;

namespace education_api.Interfaces
{
  public interface ICourseRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<GetCoursesByCategoryViewModel>> GetCourseByCategoryAsync(string category);
    public Task<List<GetCourseViewModel>> ListAllCoursesAsync();
    public Task<GetCourseViewModel?> GetCourseByCourseNrAsync(int courseNr);
    public Task AddCourseAsync(PostCourseViewModel model);
    public Task PutCourseAsync(int id, PutCourseViewModel model);
    public Task DeleteCourseAsync(int id);

  }
}