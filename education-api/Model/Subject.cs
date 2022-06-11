using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.Model
{
  public class Subject
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<TeacherSubject>? TeacherSubjects { get; set; }
  }
}