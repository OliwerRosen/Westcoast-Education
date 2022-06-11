using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.Data;
using education_api.Interfaces;
using education_api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace education_api.Controllers
{
  [ApiController]
  [Route("api/v1/studentcourse")]
  public class StudentCourseController : ControllerBase
  {
    private readonly IStudentCourseRepository _repo;

    public StudentCourseController(IStudentCourseRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<StudentCourseViewModel>>> ListAllStudentCourses()
    {
      return Ok(await _repo.ListAllStudentCoursesAsync());
    }

    [HttpGet("byStudentId/{studentId}")]
    public async Task<ActionResult<List<StudentCourseViewModel>>> ListCoursesByStudentId(int studentId)
    {
      var response = await _repo.ListCoursesByStudentId(studentId);

      if (response is null)
      {
        return NotFound($"Det går inte att hitta några kurser för student med id {studentId} i systemet.");
      }
      return Ok(response);

    }

    [HttpPost]
    public async Task<ActionResult> PostStudentCourse(StudentCourseViewModel model)
    {
      try
      {
        await _repo.AddStudentCourseAsync(model);
        if (await _repo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara kopplingen.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}