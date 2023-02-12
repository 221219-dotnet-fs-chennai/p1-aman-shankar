using Business_Logic;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using Models;

using EntityLib.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var trainer_config = builder.Configuration.GetConnectionString("Project1");
builder.Services.AddDbContext<TrainerDbContext>(options => options.UseSqlServer(trainer_config));

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IUserRepo<EntityLib.Entities.User>, UserRepo>();

builder.Services.AddScoped<ISkillLogic, SkillLogic>();
builder.Services.AddScoped<ISkillRepo, SkillRepo>();

builder.Services.AddScoped<ICompanyLogic, CompanyLogic>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();

builder.Services.AddScoped<IEducationLogic, EducationLogic>();
builder.Services.AddScoped<IEducationRepo, EducationRepo>();

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
