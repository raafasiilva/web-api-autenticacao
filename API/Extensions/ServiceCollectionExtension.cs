using API.Configurations;
using API.Interfaces.Services;
using API.Interfaces.Services.V1;
using API.Middlewares;
using API.Services;
using API.Services.V1;
using App.Domain.Interfaces.Integrations.V1;
using App.Domain.Interfaces.Kernels;
using App.Domain.Interfaces.Repositories;
using App.Domain.Interfaces.Repositories.V1;
using App.Domain.Kernels;
using App.Infraestructure.DbContexts;
using App.Infraestructure.Integrations.V1;
using App.Infraestructure.Repositories;
using App.Infraestructure.Repositories.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;

namespace API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
            services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.ConfigureAppDbContexts(configuration);
            services.ConfigureHttpClientIntegrations(configuration);
            services.ConfigureDependenciesInjections();
            services.ConfigureModelsMappings();
            services.ConfigureDocumentation();
            services.ConfigureApiVersions();
        }

        private static void ConfigureDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("documentation", new OpenApiInfo { Title = "API", Description = "API with .Net 7.0", Version = "v1.0" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o TOKEN afim de efetuar requisições que necessitem de autorização",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme() { Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }}, Array.Empty<string>()
                    }
                });
            });
        }

        private static void ConfigureDependenciesInjections(this IServiceCollection services)
        {
            // > Middlewares
            services.AddScoped<GlobalExceptionHandlerMiddleware>();
            // <

            // > Kernels.
            services.AddScoped<IExceptionNotificationKernel, ExceptionNotificationKernel>();
            // <

            // > Services.
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IAddressService, AddressService>();
            // <

            // > Repositories.
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            // <
        }

        private static void ConfigureHttpClientIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IViaCepIntegration, ViaCepIntegration>((serviceProvider, httpClient) =>
            {
                httpClient.BaseAddress = new Uri(configuration.GetValue<string>("App:IntegrationOption:AddressOption:BaseRoute"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).ConfigurePrimaryHttpMessageHandler(HttpClientConfiguration.ConfigurePrimaryHttpMessageHandler())
            .AddTransientHttpErrorPolicy(HttpClientConfiguration.ConfigureHttpErrorPolicyOrResult(3))
            .AddTransientHttpErrorPolicy(HttpClientConfiguration.ConfigureHttpErrorPolicyCircuitBreaker(3, 30));
        }

        private static void ConfigureAppDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DapperDbContext>(x => new(configuration.GetValue<string>("App:DbContextOption:ConnectionString")));
            services.AddDbContext<AuthenticationDbContext>(options => options.UseNpgsql(configuration.GetValue<string>("App:DbContextOption:ConnectionString")));
            //services.AddDbContext<EntityDbContext>(options => options.UseNpgsql(configuration.GetValue<string>("App:DbContextOption:ConnectionString")));
        }

        private static void ConfigureApiVersions(this IServiceCollection services)
        {
            IApiVersionReader[] apiVersionParams = { 
                new UrlSegmentApiVersionReader(), 
                new HeaderApiVersionReader("x-api-version"), 
                new MediaTypeApiVersionReader("x-api-version")
            };

            services.AddApiVersioning(options => 
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(apiVersionParams);
            });
        }

        private static void ConfigureModelsMappings(this IServiceCollection services) => services
            .AddSingleton(AutoMapperConfiguration.ConfigureModelMapper().CreateMapper());
    }
}
