using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.ViewModels.TeacherSubject;

namespace education_api.Interfaces
{
  public interface ITeacherSubjectRepository
  {
    public Task<bool> SaveAllAsync();
    public Task<List<GetTeacherSubjectViewModel>> ListAllTeacherSubjectsAsync();
  }
}