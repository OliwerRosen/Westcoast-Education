using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.ViewModels
{
  public class GetCourseViewModel
  {
    public int CourseNr { get; set; }
    public string? CourseTitle { get; set; }
    public string? Length { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? Details { get; set; }
    public string? ImgURL { get; set; }
  }
}