using Autofac;
using Autofac.Extensions.DependencyInjection;
using DotNetCore6.API.Config;
using DotNetCore6.API.Configuration;
using DotNetCore6.API.Configuration.Autofac;
using DotNetCore6.API.Configuration.Swagger;
using DotNetCore6.API.Filters;
using DotNetCore6.Data;
using DotNetCore6.Helpers;
using DotNetCore6.ViewModels.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");


try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModule());
    });
    // Add services to the container.

    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.EnableCors();

//Start Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(SharedProfile));
//End Auto Mapper Configurations

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.PropertyNamingPolicy
= null);
builder.Services.AddSwaggerConfig();

builder.Services.AddDbContext<Entities>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
.ConfigureWarnings(w =>
w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS))
);
//Add DbUp
builder.Services.AddDbUp(builder.Configuration);

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigCors();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), @"uploads")),
    RequestPath = new PathString("/uploads")
});
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
