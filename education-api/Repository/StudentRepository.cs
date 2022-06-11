using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using education_api.Data;
using education_api.Interfaces;
using education_api.Model;
using education_api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace education_api.Repository
{
  public class StudentRepository : IStudentRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;

    public StudentRepository(EducationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task AddStudentAsync(PostStudentViewModel model)
    {
      var studentToAdd = _mapper.Map<Student>(model);
      await _context.Students.AddAsync(studentToAdd);
    }

    public async Task<List<GetStudentViewModel>> ListAllStudentsAsync()
    {
      return await _context.Students.ProjectTo<GetStudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<GetStudentViewModel?> GetStudentByIdAsync(int Id)
    {
      return await _context.Students
      .Where(s => s.Id == Id)
      .ProjectTo<GetStudentViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();


    }

    public async Task DeleteStudentAsync(int id)
    {
      var student = await _context.Students.FindAsync(id);

      if (student is null)
      {
        throw new Exception($"Det finns ingen student med id: {id}");
      }
      else
      {
        _context.Students.Remove(student);
      }
    }

    public async Task PutStudentAsync(int id, PutStudentViewModel model)
    {
      var student = await _context.Students.FindAsync(id);
      if (student is null)
      {
        throw new Exception($"Det finns ingen student med id: {id}");
      }
      else
      {
        _mapper.Map<PutStudentViewModel, Student>(model, student);
      }
    }
  }
}