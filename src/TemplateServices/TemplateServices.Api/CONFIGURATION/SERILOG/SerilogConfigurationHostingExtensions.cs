using $safeprojectname$.Options;
using $ext_safeprojectname$Services.Common.Configuration;


namespace $safeprojectname$.Configuration;


public static class SerilogConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddSerilogInApp(this WebApplicationBuilder builder, AppOptions appOptions)
    {
        builder.Services.AddSerilogInApp(builder.Configuration, appOptions);


        return builder;
    }
}