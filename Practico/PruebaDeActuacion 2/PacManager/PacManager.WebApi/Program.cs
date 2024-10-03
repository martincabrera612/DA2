using Microsoft.EntityFrameworkCore;
using PacManager.WebApi.DataAccess;
using PacManager.WebApi.DataAccess.Grades;
using PacManager.WebApi.DataAccess.Quizzes;
using PacManager.WebApi.DataAccess.Students;
using PacManager.WebApi.Services.Grades;
using PacManager.WebApi.Services.Quizzes;
using PacManager.WebApi.Services.Students;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var services = builder.Services;

services.AddTransient<IStudentService, StudentService>();
services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<IQuizService, QuizService>();
services.AddScoped<IQuizRepository, QuizRepository>();

var connectionString = builder.Configuration.GetConnectionString("PacManagerDb");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Missing connection string");
}

services.AddDbContext<DbContext, PacManagerDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
