using API.Extensions;

WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);
webApplicationBuilder.Logging.ClearProviders();
webApplicationBuilder.Logging.AddConsole();

webApplicationBuilder.Services.ConfigureServiceCollection(webApplicationBuilder.Configuration);

WebApplication webApplication = webApplicationBuilder.Build();
webApplication.ConfigureApplicationBuilder(webApplication.Environment);
webApplication.Run();
