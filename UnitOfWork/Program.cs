using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UOW = UnitOfWork.Architecture.Infrastructure.Implementations.UnitOfWork.UnitOfWork;
using UnitOfWork.Architecture.Infrastructure.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddFluentValidation(options =>
    {
        options.AutomaticValidationEnabled = true;
        options.RegisterValidatorsFromAssemblyContaining<Program>();
        options.DisableDataAnnotationsValidation = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("MainConnectionString"));
});

builder.Services.AddScoped<IMainDbContext, MainDbContext>();

builder.Services.AddScoped<IUnitOfWork, UOW>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
