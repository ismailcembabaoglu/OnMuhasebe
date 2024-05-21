using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using OnMuhasebe.Persistence.Context;
using OnMuhasebe.Persistence.Extensions;
using OnMuhasebe.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
var loggerFactory = LoggerFactory.Create(builder => {
    builder.AddConsole();
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureMapping();
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<OnMuhasebePsqlDbContext>(config =>
{

    var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("PostgreSql"));
    config.UseLoggerFactory(loggerFactory).UseNpgsql(dataSourceBuilder.Build());
    config.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning));
    config.UseNpgsql(dataSourceBuilder.ConnectionString);
    config.EnableSensitiveDataLogging();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
