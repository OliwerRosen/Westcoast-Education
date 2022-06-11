using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.Model
{
  public class StudentCourse
  {
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student Student { get; set; } = new Student();
    public Course Course { get; set; } = new Course();
  }
}