using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {

        services.AddDbContext<DatingDbContext>(options => {
            options.UseSqlite(config.GetConnectionString("DatingDbConnection"));
        });

        services.AddCors(options =>     
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("https://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
        });
        return services;
    }
}
