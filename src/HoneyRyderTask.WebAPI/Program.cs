using System.Reflection;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;
using HoneyRyderTask.Infrastructure.PostgreSQL;
using HoneyRyderTask.Infrastructure.PostgreSQL.Repositories.Tasks;
using HoneyRyderTask.UseCase.Services.Tasks.RegisterTask;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddApiVersioning();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<IDateTimeProvider, DefaultDateTimeProvider>();

builder.Services.AddTransient<RegisterTaskUseCase>();

builder.Services.AddTransient<ITaskFactory, HoneyRyderTask.Domain.Services.Tasks.TaskFactory>();

builder.Services.AddTransient<ITaskRepository, TaskRepository>();

builder.Services.AddDbContext<HoneyRyderTaskDbContext>();

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
