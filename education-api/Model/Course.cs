using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.Model
{
  public class Course
  {
    [Key]
    public int CourseNr { get; set; }
    public string? CourseTitle { get; set; }
    public string? Length { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? Details { get; set; }
    public string? ImgURL { get; set; }
    public ICollection<StudentCourse>? StudentCourses { get; set; }
  }
}