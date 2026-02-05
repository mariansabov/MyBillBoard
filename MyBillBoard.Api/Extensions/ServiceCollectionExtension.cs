using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBillBoard.Infrastructure.Persistence;

namespace MyBillBoard.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}
