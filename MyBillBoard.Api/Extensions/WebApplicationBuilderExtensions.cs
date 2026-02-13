namespace MyBillBoard.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.ConfigureServices(builder.Configuration);

            return builder;
        }
    }
}
