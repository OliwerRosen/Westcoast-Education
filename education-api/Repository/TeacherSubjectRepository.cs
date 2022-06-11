using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using education_api.Data;
using education_api.Interfaces;
using education_api.ViewModels.Teacher;
using education_api.ViewModels.TeacherSubject;

namespace education_api.Repository
{
  public class TeacherSubjectRepository : ITeacherSubjectRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;

    public TeacherSubjectRepository(EducationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public Task<List<GetTeacherSubjectViewModel>> ListAllTeacherSubjectsAsync()
    {
      throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
      throw new NotImplementedException();
    }
  }
}