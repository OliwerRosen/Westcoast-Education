using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.Model
{
  public class Student
  {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNr { get; set; }
    public string? Address { get; set; }
    public ICollection<StudentCourse>? StudentCourses { get; set; }
    // public int AddressId { get; set; }

    // [ForeignKey("StudentAddressId")]
    // public Address Address { get; set; } = new Address();
  }
}