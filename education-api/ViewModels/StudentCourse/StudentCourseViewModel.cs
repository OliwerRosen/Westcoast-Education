using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.ViewModels
{
  public class StudentCourseViewModel
  {
    [Required(ErrorMessage = "Skriv in StudentId")]
    public int? StudentId { get; set; }

    [Required(ErrorMessage = "Skriv in KursId")]
    public int? CourseId { get; set; }
  }
}