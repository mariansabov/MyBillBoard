using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MyBillBoard.Application.Common.Behaviors;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.Announcements;
using MyBillBoard.Infrastructure.Persistence;
using System.Reflection;

namespace MyBillBoard.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var assemblies = new[] { typeof(Program).Assembly, typeof(CreateAnnouncementCommand).Assembly };

            services.AddControllers();

            services
                .AddHttpContextAccessor()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBillBoard Api", Version = "v1" });
                })
                .AddDbContext(configuration)
                .AddMediatR(assemblies)
                .AddAutoMapper(cfg => cfg.AddMaps(assemblies))
                .AddValidatorsFromAssemblies(assemblies);

            return services;
        }

        public static IServiceCollection AddMediatR(
            this IServiceCollection services,
            Assembly[] assemblies
        )
        {
            return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IMyDbContext>(provider =>
                provider.GetRequiredService<MyDbContext>()
            );

            return services;
        }
    }
}
