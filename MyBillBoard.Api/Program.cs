using Microsoft.EntityFrameworkCore;
using MyBillBoard.Api.Extensions;
using MyBillBoard.Infrastructure.Persistence;

namespace MyBillBoard.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = WebApplication.CreateBuilder(args).ConfigureServices().Build().ConfigureApp();

            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();

            context.Database.Migrate();
            context.Seed();

            app.Run();
        }
    }
}
