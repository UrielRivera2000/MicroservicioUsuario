using UserService.Application.Interfaces;
using UserService.Application.UseCases.CreateUser;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Extensions;
using UserService.Infrastructure.ExternalServices;
using UserService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Agregar Log4Net al sistema de logging de .NET  
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net("log4net.config");

builder.Services.AddLoggingAdapter();

builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddHttpClient<INotificationService, NotificationHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7225");
});

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
