using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core;
using HexTest.Application;
using HexTest.Application.Workflows;
using HexTest.Infrastructure;
using HexTest.Infrastructure.Data;
using HexTest.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Utilities.ConfigReader;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

//Loading Site.Config
Utilities.Common.ProjectProperties = new Properties(AppDomain.CurrentDomain.BaseDirectory + "\\site.config");


Log.Information("Starting Web Host");

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.UseSerilog();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

//Build Database ConnectionString
HexTest.Infrastructure.Data.Common.ConnectionString = String.Format(builder.Configuration.GetConnectionString("DBConnection"),
                                Utilities.Common.ProjectProperties.get("HostName", "localhost"),
                                Utilities.Common.ProjectProperties.get("UserID", "root"),
                                Utilities.Common.ProjectProperties.get("Password", "root"),
                                Utilities.Common.ProjectProperties.get("DatabaseName", ""),
                                Utilities.Common.ProjectProperties.get("Port", "3306")
                            );

HexTest.Infrastructure.Data.Common.Database = Utilities.Common.ProjectProperties.get("Database", "MySql");


//Create DBContext based on configuration
Log.Information("Using " + Utilities.Common.ProjectProperties.get("Database", "") + " Database");

switch(HexTest.Infrastructure.Data.Common.Database)
{
    case "MySql":
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(HexTest.Infrastructure.Data.Common.ConnectionString, ServerVersion.Create(5, 5, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql), null) );
        break;
    case "MariaDB":
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(HexTest.Infrastructure.Data.Common.ConnectionString, ServerVersion.Create(5, 5, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb), null));
        break;
    case "MSSqlServer":
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(HexTest.Infrastructure.Data.Common.ConnectionString));
        break;
    case "SQLite":
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(HexTest.Infrastructure.Data.Common.ConnectionString));
        break;
    case "Oracle":
        builder.Services.AddDbContext<AppDbContext>(options => options.UseOracle(HexTest.Infrastructure.Data.Common.ConnectionString));
        break;
    case "PostgreSQL":
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(HexTest.Infrastructure.Data.Common.ConnectionString));
        break;
    default:
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(HexTest.Infrastructure.Data.Common.ConnectionString, ServerVersion.Create(5, 5, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql), null));
        break;
}

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();

builder.Services.AddControllers(options =>
{
    options.UseNamespaceRouteToken();
});

//builder.Services.AddScoped<BaseProcess, Process>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "HexTest API", Version = "v1" });
    options.EnableAnnotations();
    options.CustomSchemaIds(i => i.FullName);
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                    }
                },
                new string[] {}
        }
    });
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericRepository<>));


// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultApplicationModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});


builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

var app = builder.Build();

//Configure the HTTP request pipeline.
app.UseSerilogRequestLogging(configure =>
{
    configure.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
}); // We want to log all HTTP requests

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HexTest API V1"));

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    //context.Database.Migrate();
    context.Database.EnsureCreated();
    //SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB.");
    Log.Error(ex, "An error occurred seeding the DB.");
  }
}

app.Run();
