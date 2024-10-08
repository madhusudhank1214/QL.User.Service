using FluentValidation;
using FluentValidation.AspNetCore;
using LMSService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QL.Infra.Models.Training;
using QL.Infra.Repository.InfraRepos;
using QL.Infra.Repository.Repositories;
using UserService.API.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Program>();
                });

builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmployeeWFHRequest, EmployeeWFHRequest>();
builder.Services.AddTransient<IInnovateideaRepository, InnovateideaRepository>();
builder.Services.AddTransient<IMasterInfomation, MasterInfomation>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<IScheduleTraining,ScheduleTrainingRepository>();

builder.Services.AddTransient<IValidator<ScheduleTraining>, ScheduleTrainingValidator>();
builder.Services.AddTransient<IValidator<List<ScheduleTraining>>, ListScheduleTrainingValidator>();


builder.Services.AddTransient<IQLTrainingsRepository, QLTrainingsRepository>();
builder.Services.AddScoped<LMSService.IEmailSender, SmtpEmailSender>();
builder.Services.Configure<MailserverConfiguration>(builder.Configuration.GetSection("MailserverDev"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


