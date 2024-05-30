using System;
using System.Text;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityTokenExtensions
{
    public static IServiceCollection AddIdentityTokenService(this IServiceCollection services, IConfiguration config) {

        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

            options.TokenValidationParameters = new TokenValidationParameters {

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }
}
