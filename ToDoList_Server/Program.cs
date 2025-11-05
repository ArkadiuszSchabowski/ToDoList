using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ToDoList_Server.Interfaces;
using ToDoList_Server.Interfaces.Aggregates;
using ToDoList_Server.Middleware;
using ToDoList_Server.Repositories;
using ToDoList_Server.Services;
using ToDoList_Server.Validators;
using ToDoList_Server.Validators.Aggregates;
using ToDoList_Server_Database;
using ToDoList_Server_Database.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<ITaskAggregateService, TaskService>();
builder.Services.AddScoped<ITaskAggregateRepository, TaskRepository>();
builder.Services.AddScoped<ITaskAggregateValidator, TaskAggregateValidator>();

builder.Services.AddScoped<IValidatorId, ValidatorId>();
builder.Services.AddScoped<ITaskValidator, TaskValidator>();
builder.Services.AddScoped<IEntityValidator<TaskItem>, EntityValidator>();
builder.Services.AddScoped<IPaginationValidator, PaginationValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
