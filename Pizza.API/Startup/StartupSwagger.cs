namespace Pizza.API.Startup;

public static class StartupSwagger
{
    public static void ConfigureSwagger(this IApplicationBuilder app, ConfigurationManager configuration)
    {
        var swaggerRouteTemplatePrefix = configuration.GetValue<string>("Swagger:RouteTemplatePrefix");

        app.UseSwagger(options =>
        {
            options.RouteTemplate = $"{swaggerRouteTemplatePrefix}/{{documentname}}/swagger.json";
        });

        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = swaggerRouteTemplatePrefix;
        });
    }
}
