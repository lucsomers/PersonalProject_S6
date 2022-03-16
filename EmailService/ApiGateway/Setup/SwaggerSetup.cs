using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace ApiGateway.Setup
{
    public class SwaggerSetup
    {
        private const string version = "v1";
        private const string authorizationName = "Authorization";
        private const string authorizationDescription = "JWT Authorization header using the Bearer scheme";

        public void Setup(IServiceCollection services, string serviceName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = $"{serviceName} API",
                    Version = version
                });

                //This code adds the authentication button on the top right of the swagger UI. It created the option
                //of passing the token in the header to each backend call made for testing account specific functions.
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = authorizationName,
                    In = ParameterLocation.Header,
                    Description = authorizationDescription,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
