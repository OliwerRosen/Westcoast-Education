using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.ViewModels;

namespace education_api.Interfaces
{
  public interface IStudentRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<GetStudentViewModel>> ListAllStudentsAsync();
    public Task<GetStudentViewModel?> GetStudentByIdAsync(int Id);
    public Task AddStudentAsync(PostStudentViewModel model);
    public Task PutStudentAsync(int id, PutStudentViewModel model);
    public Task DeleteStudentAsync(int id);
  }
}