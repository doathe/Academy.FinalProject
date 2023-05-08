
using ECommerce.API.Middlewares;
using ECommerce.Application;
using ECommerce.Application.Users.Commands.UserRegistration;
using ECommerce.Infrastructure.EFCore;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserRegistrationCommandValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddEFCoreDependencyInjection(config);
builder.Services.AddApplicationDependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();