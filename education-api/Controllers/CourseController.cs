using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.Interfaces;
using education_api.ViewModels;
using education_api.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;

namespace education_api.Controllers
{
  [ApiController]
  [Route("api/v1/courses")]
  public class CourseController : ControllerBase
  {
    private readonly ICourseRepository _courseRepo;

    public CourseController(ICourseRepository courseRepo)
    {
      _courseRepo = courseRepo;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<GetCourseViewModel>>> ListAllCourses()
    {
      return Ok(await _courseRepo.ListAllCoursesAsync());
    }

    [HttpGet("category/{category}")]
    //public async Task<ActionResult<List<PostCourseViewModel>>> GetCourseByCategory([FromQuery] string category)
    public async Task<ActionResult<List<PostCourseViewModel>>> GetCourseByCategory(string category)
    {
      return Ok(await _courseRepo.GetCourseByCategoryAsync(category));
    }

    [HttpGet("{courseNr}")]
    public async Task<ActionResult<GetCourseViewModel>> GetCourseByCourseNr(int courseNr)
    {
      var response = await _courseRepo.GetCourseByCourseNrAsync(courseNr);

      if (response is null)
      {
        return NotFound($"Det finns ingen kurs med kursnummer {courseNr} i systemet.");
      }
      return Ok(response);
    }
    [HttpPost()]
    public async Task<ActionResult> AddCourse(PostCourseViewModel model)
    {
      try
      {
        await _courseRepo.AddCourseAsync(model);

        if (await _courseRepo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara kursen.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCourse(int id, PutCourseViewModel model)
    {
      try
      {
        await _courseRepo.PutCourseAsync(id, model);

        if (await _courseRepo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara kursen.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCourse(int id)
    {
      try
      {
        await _courseRepo.DeleteCourseAsync(id);

        if (await _courseRepo.SaveAllAsync())
        {
          return NoContent();
        }

        return StatusCode(500, "Det gick inte att spara bortagningen av kursen.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }

    }
  }
}