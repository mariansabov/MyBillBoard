using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyBillBoard.Api.Extensions;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Services;
using MyBillBoard.Infrastructure.Persistence;
using MyBillBoard.Infrastructure.Repositories;
using MyBillBoard.Application.Common.Behaviors;
using MyBillBoard.Application.Features.Categories.Validators;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container

builder.Services.AddDatabase(configuration);

builder.Services.AddControllers();

// ------------------------
// MediatR
// ------------------------
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(MyBillBoard.Application.Features.Categories.CreateCategoryCommand).Assembly));

// ------------------------
// FluentValidation
// ------------------------
builder.Services.AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly);

// ------------------------
// Pipeline Behavior
// ------------------------
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAnnouncementsService, AnnouncementsService>();
builder.Services.AddScoped<IAnnouncementsRepository, AnnouncementsRepository>();

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

builder.Services.AddScoped<ISubCategoriesRepository, SubCategoriesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();

context.Database.Migrate();
context.Seed();

app.Run();
