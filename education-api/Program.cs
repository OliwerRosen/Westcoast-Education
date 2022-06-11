using education_api.AutoMapper;
using education_api.Data;
using education_api.Interfaces;
using education_api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EducationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))
);


builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherSubjectRepository, TeacherSubjectRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
  options.AddPolicy("WestCoastCors",
    policy =>
    {
      policy.AllowAnyHeader();
      policy.AllowAnyMethod();
      policy.WithOrigins(
      "http://127.0.0.1:5500",
      "http://localhost:7212",
      "http://localhost:3000");
    }
  );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("WestCoastCors");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
  var context = services.GetRequiredService<EducationContext>();
  await context.Database.MigrateAsync();
  await LoadData.LoadTeachers(context);
  await LoadData.LoadCourses(context);
  await LoadData.LoadStudents(context);
  await LoadData.LoadSubjects(context);
  await LoadData.LoadTeacherSubjects(context);
  await context.SaveChangesAsync();

}
catch (Exception ex)
{
  var logger = services.GetRequiredService<ILogger<Program>>();
  logger.LogError(ex, "Ett fel inträffade när migrering utfördes");
}

await app.RunAsync();
