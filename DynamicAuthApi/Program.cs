
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DynamicAuthApi.Middlewaare;
//using DynamicAuthApi.AuthorizationRequirement;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using System.Reflection;
//using Infrastructure.Answers.Query;
using MediatR;
using Domain.DTO;
using Infrastructure.MapperProfile;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Diagnostics;
//using Infrastructure.Answers.Commands;

namespace DynamicAuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddControllers().AddJsonOptions(x =>
            //   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Add services to the container.
            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging(); 

            });
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout
                options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });
            builder.Services.AddDistributedMemoryCache();
           builder.Services.AddHttpContextAccessor();


            //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            //builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            //    builder.RegisterModule(new AutoFacModule()));

            //builder.Services.AddTransient<GlobalErrorHandlerMiddleware>();
            //builder.Services.AddScoped<TransactionMiddleware>();
            //builder.Services.AddScoped<Context>();
            //builder.Services.AddTransient<CustomMiddleWare>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped< UnitOfWork>();
            //builder.Services.AddScoped<assessment_Answers_Service, assessment_Answers_Service>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IExamService, ExamService>();
            builder.Services.AddScoped<IEvaluateExamService, EvaluateExamService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IChoiceService, ChoiceService>();
            builder.Services.AddScoped<IAnswerService, AnswerService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            //builder.Services.AddScoped<IMemberService, MemberService>();
            //builder.Services.AddTransient<IRequestHandler<AnswerByIdQuery, assessment_answers>, AnswerQueryHandler>();
            //builder.Services.AddTransient<IRequestHandler<AnswerAddCommand, Assessment_AnswersDTO>, AnswerCommandHandler>();

            //builder.Services.AddScoped<IAuthorizationHandler, GroupPermissionAuthorizationHandler>();
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())); // instead name of each one 
            builder.Services.AddAutoMapper(typeof(QuestionProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(ExamProfiler).Assembly);
            builder.Services.AddAutoMapper(typeof(AnswerProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(ChoiceProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(CourseProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(MemberProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(UserProfiler).Assembly);
            builder.Services.AddAutoMapper(typeof(TaskProfile).Assembly);
            builder.Services.AddLogging(builder => builder.AddDebug());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<CustomMiddleWare>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider.GetRequiredService<Context>;
            //    services.Invoke();
            //}

            app.UseSession();
            //app.UseMvc();
            //app.useR
            app.MapControllers();

            app.Run();
        }
    }
}