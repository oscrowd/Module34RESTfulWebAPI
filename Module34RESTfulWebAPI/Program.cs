using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Module34RESTfulWebAPI;
using Module34RESTfulWebAPI.Configuration;
using Swashbuckle.Swagger.Application;
using System.Reflection;
using FluentValidation.Validators;
using FluentValidation.AspNetCore;
using Home

class Program
{
    private static IConfiguration Configuration
    { get; } = new ConfigurationBuilder()
  .AddJsonFile("HomeOptions.json")
  .AddJsonFile("appsettings.json")
  .Build();
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // Добавляем новый сервис
        builder.Services.Configure<HomeOptions>(Configuration);

        builder.Services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "HomeApi",
                Version = "v1"
            });
        });
        // Подключаем валидацию
        builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDeviceRequestValidator>());
        

        // Подключаем автомаппинг
        var assembly = Assembly.GetAssembly(typeof(MappingProfile));
        builder.Services.AddAutoMapper(assembly);
        var app = builder.Build();

        

        // Configure the HTTP request pipeline.

        app.UseAuthorization();

        app.MapControllers();
        

        app.Run();

    }
}

