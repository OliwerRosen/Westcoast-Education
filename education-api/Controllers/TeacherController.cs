using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using education_api.Interfaces;
using education_api.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace education_api.Controllers
{
  [ApiController]
  [Route("api/v1/teacher")]
  public class TeacherController : ControllerBase
  {
    private readonly ITeacherRepository _repo;
    public TeacherController(ITeacherRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("list")]
    public async Task<ActionResult<List<GetTeacherViewModel>>> ListAllTeachers()
    {
      return Ok(await _repo.ListAllTeachersAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<GetTeacherViewModel>> GetTeacherById(int id)
    {
      var result = await _repo.GetTeacherByIdAsync(id);
      if (result is null)
      {
        return NotFound($"Det finns ingen läraren med id {id} i systemet.");
      }
      return Ok(result);
    }

    [HttpPost()]
    public async Task<ActionResult> AddTeacher(PostTeacherViewModel model)
    {
      try
      {
        await _repo.AddTeacherAsync(model);

        if (await _repo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara läraren.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeacher(int id)
    {
      try
      {
        await _repo.DeleteTeacherAsync(id);
        if (await _repo.SaveAllAsync())
        {
          return NoContent();
        }
        return StatusCode(500, "Det gick inte att spara borttagningen av läraren.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> PutTeacher(int id, PutTeacherViewModel model)
    {
      try
      {
        await _repo.PutTeacherAsync(id, model);

        if (await _repo.SaveAllAsync())
        {
          return StatusCode(201);
        }
        return StatusCode(500, "Det gick inte att spara läraren.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}