using System.Text.Json.Serialization;


namespace $safeprojectname$.Configuration;


public static class ControllersConfigurationHostingExtensions
{
    public static IHostApplicationBuilder AddControllersInApp(this IHostApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddJsonOptions(jsonOpt =>
            {
                jsonOpt.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.SnakeCaseLower;
                jsonOpt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });


        return builder;
    }
}
