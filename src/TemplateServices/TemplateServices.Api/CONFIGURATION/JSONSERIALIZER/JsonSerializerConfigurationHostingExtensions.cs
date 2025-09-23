using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class JsonSerializerConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddJsonSerializerInApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddJsonSerializerInApp();

        
        return builder;
    }
}
