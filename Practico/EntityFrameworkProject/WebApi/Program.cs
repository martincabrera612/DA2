using DataAccess;
using DataAccess.Repositories.UserDataAccess;
using Microsoft.EntityFrameworkCore;
using WebApi.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var services = builder.Services;
var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("AppDb");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Missing connection string");
}
services.AddDbContext<DbContext, AppDbContext>(options => options.UseSqlServer(connectionString));

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
