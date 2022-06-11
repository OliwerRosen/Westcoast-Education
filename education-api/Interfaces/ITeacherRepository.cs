using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.ViewModels.Teacher;

namespace education_api.Interfaces
{
  public interface ITeacherRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<GetTeacherViewModel>> ListAllTeachersAsync();
    public Task<GetTeacherViewModel?> GetTeacherByIdAsync(int Id);
    public Task AddTeacherAsync(PostTeacherViewModel model);
    public Task PutTeacherAsync(int id, PutTeacherViewModel model);
    public Task DeleteTeacherAsync(int id);
  }
}