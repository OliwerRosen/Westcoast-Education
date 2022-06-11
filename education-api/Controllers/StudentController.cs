using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.Interfaces;
using education_api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace education_api.Controllers
{
  [ApiController]
  [Route("api/v1/student")]
  public class StudentController : ControllerBase
  {
    private readonly IStudentRepository _studentRepo;
    public StudentController(IStudentRepository studentRepo)
    {
      _studentRepo = studentRepo;

    }

    [HttpGet("list")]
    public async Task<ActionResult<List<GetStudentViewModel>>> ListAllStudents()
    {
      return Ok(await _studentRepo.ListAllStudentsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetStudentViewModel>> GetStudentById(int id)
    {
      var result = await _studentRepo.GetStudentByIdAsync(id);
      if (result is null)
      {
        return NotFound($"Det finns ingen student med id {id} i systemet.");
      }
      return Ok(result);
    }

    [HttpPost()]
    public async Task<ActionResult> AddStudent(PostStudentViewModel model)
    {
      try
      {
        await _studentRepo.AddStudentAsync(model);

        if (await _studentRepo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara studenten.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
      try
      {
        await _studentRepo.DeleteStudentAsync(id);
        if (await _studentRepo.SaveAllAsync())
        {
          return NoContent();
        }
        return StatusCode(500, "Det gick inte att spara borttagningen av studenten.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> PutStudent(int id, PutStudentViewModel model)
    {
      try
      {
        await _studentRepo.PutStudentAsync(id, model);

        if (await _studentRepo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara studenten.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

  }
}