using Education.Application.Cursos;
using Education.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EducationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddMediatR(typeof(GetCursoQuery.GetCursoQueryHandler).Assembly);  // Uso de MediatR
builder.Services.AddAutoMapper(typeof(GetCursoQuery.GetCursoQueryHandler)); // Uso de AutoMapper

builder.Services.AddControllers()
        .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateCursoCommand>());  // Uso de FluentValidation


// Configuración de los  CORS
builder.Services.AddCors(o => o.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseCors("corsApp");  

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
