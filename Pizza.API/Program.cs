using CorrelationId;
using Pizza.API.Startup;
using Pizza.Infrastructure.Persistence;
using Serilog;

Log.Logger = StartupLogging.CreateBootstrapLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(StartupLogging.ConfigureLogger);
    builder.Services.RegisterServices(builder.Configuration);

    var app = builder.Build();

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    seeder.Seed();

    app.ConfigureSwagger(builder.Configuration);
    app.UseSerilogRequestLogging();
    app.UseCorrelationId();
    app.UseHttpsRedirection();
    app.UseCors();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
