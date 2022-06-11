using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using education_api.Data;
using education_api.Interfaces;
using education_api.ViewModels;
using education_api.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using education_api.ViewModels.Course;

namespace education_api.Repository
{
  public class CourseRepository : ICourseRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;

    public CourseRepository(EducationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task AddCourseAsync(PostCourseViewModel model)
    {
      var response = await _context.Courses.Where(c => c.CourseNr == model.CourseNr).SingleOrDefaultAsync();

      if (response is not null)
      {
        throw new Exception($"Det finns redan en kurs med kursnummer {model.CourseNr} i systemet.");
      }

      var courseToAdd = _mapper.Map<Course>(model);
      await _context.Courses.AddAsync(courseToAdd);
    }

    public async Task<List<GetCoursesByCategoryViewModel>> GetCourseByCategoryAsync(string category)
    {
      return await _context.Courses
      .Where(c => c.Category!.ToLower() == category.ToLower())
      .ProjectTo<GetCoursesByCategoryViewModel>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }

    public async Task<GetCourseViewModel?> GetCourseByCourseNrAsync(int courseNr)
    {
      return await _context.Courses.Where(c => c.CourseNr == courseNr)
      .ProjectTo<GetCourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }

    public async Task<List<GetCourseViewModel>> ListAllCoursesAsync()
    {
      return await _context.Courses.ProjectTo<GetCourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task PutCourseAsync(int id, PutCourseViewModel model)
    {
      var course = await _context.Courses.FindAsync(id);

      if (course is null)
      {
        throw new Exception($"Det finns ingen kurs med id: {id}");
      }

      _mapper.Map<PutCourseViewModel, Course>(model, course);

      //_context.Courses.Update(course);
    }

    public async Task DeleteCourseAsync(int id)
    {
      var course = await _context.Courses.FindAsync(id);

      if (course is null)
      {
        throw new Exception($"Det finns ingen kurs med id: {id}");
      }
      if (course is not null)
      {
        _context.Courses.Remove(course);
      }
    }

  }
}