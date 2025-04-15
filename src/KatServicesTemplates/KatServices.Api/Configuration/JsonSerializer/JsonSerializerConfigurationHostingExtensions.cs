using KatServices.Common.Configuration;


namespace KatServices.Api.Configuration;


public static class JsonSerializerConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddJsonSerializerInApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddJsonSerializerInApp();
        return builder;
    }
}
