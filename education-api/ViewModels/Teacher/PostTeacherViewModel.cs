using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.ViewModels.Teacher
{
  public class PostTeacherViewModel
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Skriv in förnamn")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Skriv in efternamn")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Skriv in E-postaddress")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Skriv in telefonnummer")]
    public string? PhoneNr { get; set; }
    [Required(ErrorMessage = "Skriv in Address")]
    public string? Address { get; set; }
  }
}