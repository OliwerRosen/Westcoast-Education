using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using education_api.Data;
using education_api.Interfaces;
using education_api.Model;
using education_api.ViewModels.Teacher;
using Microsoft.EntityFrameworkCore;

namespace education_api.Repository
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;

    public TeacherRepository(EducationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<List<GetTeacherViewModel>> ListAllTeachersAsync()
    {
      return await _context.Teachers.ProjectTo<GetTeacherViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task AddTeacherAsync(PostTeacherViewModel model)
    {
      var teacherToAdd = _mapper.Map<Teacher>(model);
      await _context.Teachers.AddAsync(teacherToAdd);
    }


    public async Task<GetTeacherViewModel?> GetTeacherByIdAsync(int Id)
    {
      return await _context.Teachers
      .Where(s => s.Id == Id)
      .ProjectTo<GetTeacherViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();


    }

    public async Task DeleteTeacherAsync(int id)
    {
      var teacher = await _context.Teachers.FindAsync(id);

      if (teacher is null)
      {
        throw new Exception($"Det finns ingen lärare med id: {id}");
      }
      else
      {
        _context.Teachers.Remove(teacher);
      }
    }

    public async Task PutTeacherAsync(int id, PutTeacherViewModel model)
    {
      var teacher = await _context.Teachers.FindAsync(id);
      if (teacher is null)
      {
        throw new Exception($"Det finns ingen lärare med id: {id}");
      }
      else
      {
        _mapper.Map<PutTeacherViewModel, Teacher>(model, teacher);
      }
    }
  }
}
