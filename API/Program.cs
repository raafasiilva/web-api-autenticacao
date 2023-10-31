using API.Extensions;
using Microsoft.AspNetCore.Mvc.Versioning;

WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
webApplicationBuilder.Logging.ClearProviders();
webApplicationBuilder.Logging.AddConsole();

webApplicationBuilder.Services.ConfigureServiceCollection(webApplicationBuilder.Configuration);

WebApplication webApplication = webApplicationBuilder.Build();
webApplication.ConfigureApplicationBuilder(webApplication.Environment);
webApplication.Run();