using Microsoft.OpenApi.Models;

namespace MysticMadness.WebService.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "MysticMadnessAPI", Version = configuration["Version"] });

            var securitySchema = new OpenApiSecurityScheme()
            {
                Description = "Using the Authorization header with the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Reference = new()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securitySchema);
            c.AddSecurityRequirement(new()
            {
                { securitySchema, ["Bearer"] }
            });
        });
        return services;
    }
}