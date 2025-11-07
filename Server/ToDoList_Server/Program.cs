using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ToDoList_Server.Interfaces;
using ToDoList_Server.Interfaces.Aggregates;
using ToDoList_Server.Middleware;
using ToDoList_Server.Repositories;
using ToDoList_Server.Seeders;
using ToDoList_Server.Services;
using ToDoList_Server.Validators;
using ToDoList_Server.Validators.Aggregates;
using ToDoList_Server_Database;
using ToDoList_Server_Database.Entities;

var builder = WebApplication.CreateBuilder(args);

var isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
if (isDocker)
{
    builder.WebHost.UseUrls("http://*:5000");
}

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost", "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("MyDbConnectionString")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<ITaskAggregateService, TaskService>();
builder.Services.AddScoped<ITaskAggregateRepository, TaskRepository>();
builder.Services.AddScoped<ITaskAggregateValidator, TaskAggregateValidator>();

builder.Services.AddScoped<IValidatorId, ValidatorId>();
builder.Services.AddScoped<ITaskValidator, TaskValidator>();
builder.Services.AddScoped<IEntityValidator<TaskItem>, EntityValidator>();
builder.Services.AddScoped<IPaginationValidator, PaginationValidator>();

builder.Services.AddScoped<ISeeder, TaskSeeder>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MyDbContext>();
    context.Database.Migrate();

    var taskSeeder = services.GetRequiredService<ISeeder>();

    taskSeeder.SeedData();
}

    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
