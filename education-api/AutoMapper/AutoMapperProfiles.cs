using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using education_api.Model;
using education_api.ViewModels;
using education_api.ViewModels.Course;
using education_api.ViewModels.Teacher;

namespace education_api.AutoMapper
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      //course
      CreateMap<Course, GetCourseViewModel>();
      CreateMap<Course, GetCoursesByCategoryViewModel>();
      CreateMap<PostCourseViewModel, Course>();
      CreateMap<PutCourseViewModel, Course>();

      //student
      CreateMap<Student, GetStudentViewModel>();
      CreateMap<PostStudentViewModel, Student>();
      CreateMap<PutStudentViewModel, Student>();

      //teacher
      CreateMap<Teacher, GetTeacherViewModel>();
      CreateMap<PostTeacherViewModel, Teacher>();
      CreateMap<PutTeacherViewModel, Teacher>();

      //studentcourse
      CreateMap<StudentCourse, StudentCourseViewModel>();



    }
  }
}

//.ForMember(s => s.Address.StudentAddressId, a => a.MapFrom(s => s.StudentAdressId));