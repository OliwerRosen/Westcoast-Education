using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.ViewModels
{
  public class PostCourseViewModel
  {
    [Required(ErrorMessage = "Skriv in kursnummer")]
    public int CourseNr { get; set; }
    [Required(ErrorMessage = "Skriv in kurstitel")]
    public string? CourseTitle { get; set; }
    [Required(ErrorMessage = "Skriv in kurslängd (DD/HH)")]
    public string? Length { get; set; }
    [Required(ErrorMessage = "Skriv in kategori")]
    public string? Category { get; set; }
    [Required(ErrorMessage = "Skriv in beskrivning")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Skriv in detaljer")]
    public string? Details { get; set; }
    [Required(ErrorMessage = "Skriv in bildlänk")]
    public string? ImgURL { get; set; }
  }
}