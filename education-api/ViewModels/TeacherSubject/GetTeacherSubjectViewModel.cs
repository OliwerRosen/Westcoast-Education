using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.ViewModels.TeacherSubject
{
  public class GetTeacherSubjectViewModel
  {
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
  }
}