using API_VozyChatOps.Data;
using API_VozyChatOps.Repositories.Implementations;
using API_VozyChatOps.Repositories.Interfaces;
using API_VozyChatOps.Security.Repositories;
using API_VozyChatOps.Security.Services;
using API_VozyChatOps.Services;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyeccion de dependencias
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ScheduleService>();
builder.Services.AddScoped<PDFGenerationService>();
builder.Services.AddScoped<ResetPasswordService>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<AuthService>();



builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Desarrollo")));

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
