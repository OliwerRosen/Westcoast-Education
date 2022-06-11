using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace education_api.Model
{
  public class Address
  {
    public int Id { get; set; }
    public string? Street { get; set; }
    public int StreetNr { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public int ZipCode { get; set; }
    public ICollection<Student> Student { get; set; } = new List<Student>();

  }
}