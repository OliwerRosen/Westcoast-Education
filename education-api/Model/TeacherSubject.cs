using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.Model
{
  public class TeacherSubject
  {
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    public Teacher Teacher { get; set; } = new Teacher();
    public Subject Subject { get; set; } = new Subject();
  }
}