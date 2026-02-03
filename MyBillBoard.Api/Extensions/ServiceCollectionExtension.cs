using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBillBoard.Infrastructure.Persistence;

namespace MyBillBoard.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseNpgsql("Host=localhost;Database=MyBillBoardDb;Username=postgres;Password=1234pg");
                });
        }
    }
}
