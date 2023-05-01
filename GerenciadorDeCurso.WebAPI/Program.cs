using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciadorDeCurso.Application.Services;
using GerenciadorDeCurso.Core.DTOs;
using GerenciadorDeCurso.Core.Interface;
using GerenciadorDeCurso.Core.Validations;
using GerenciadorDeCurso.Infraestructure.Context;
using GerenciadorDeCurso.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITurmaAlunoRepository, TurmaAlunoRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();


builder.Services.AddTransient<IValidator<AlunoDTO>, AlunoValidator>();
string sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlServerConnection));

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
