using CorrelationId.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Pizza.API.Filters;
using Pizza.Application;
using Pizza.Infrastructure.Persistence;

namespace Pizza.API.Startup;

public static class StartupInjection
{
    public static void RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers(options => options.Filters.Add<GlobalExceptionHandlingFilter>())
            .ConfigureJson();

        services.ConfigureSwagger();

        services.AddDefaultCorrelationId();
        services.AddCors(options => options.AddPolicy(
            Constants.AllowAll,
            policy => policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

        services.AddHttpContextAccessor();

        services.AddDatabaseAndSeeder(configuration);
        services.AddRepositories();
        services.AddServices();
        services.ConfigureAutoMapper();
    }

    private static void ConfigureSwagger(this IServiceCollection services)
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var xmlDocName = typeof(StartupInjection).Assembly.GetName().Name + ".xml";
        var xmlDocPath = Path.Combine(basePath, xmlDocName);

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza.API", Version = "v1" });
            opt.IncludeXmlComments(xmlDocPath);
        })
            .AddSwaggerGenNewtonsoftSupport();
    }

    private static IMvcBuilder ConfigureJson(this IMvcBuilder builder)
    {
        return builder.AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Formatting = Formatting.Indented;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //output enums as string in JSON
            options.SerializerSettings.Converters.Add(new StringEnumConverter(typeof(CamelCaseNamingStrategy)));
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // above settings don't apply to JsonConvert calls,
            // therefore it requires to be configured separately
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        });
    }
}
