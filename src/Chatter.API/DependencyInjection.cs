using Chatter.Common.ConfigurationModels;
using Chatter.WebUI.Extensions;
using Chatter.WebUI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quantum.DAL.Infrastructure;
using System.Threading.Tasks;

namespace Chatter.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSetting<DatabaseSettings>(configuration);
            services.ConfigureSetting<JwtSettings>(configuration);
            AddAuthentication(services, configuration);

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSignalR();

            services.AddCors(options => options.AddPolicy("AllowAllOrigin",
                                                 builder => builder.AllowAnyHeader()
                                                                   .AllowAnyMethod()
                                                                   .SetIsOriginAllowed((host) => true)
                                                                   .WithOrigins("http://localhost:4200")
                                                                   .AllowCredentials()));

            return services;
        }

        public static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(tokenOpt => {
                    tokenOpt.RequireHttpsMetadata = false; // SSL не используется
                    tokenOpt.TokenValidationParameters = new JwtAuthParameters(configuration);

                    tokenOpt.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}
