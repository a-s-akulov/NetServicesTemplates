using $safeprojectname$;


var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.Logger.LogInformation("--- Запуск службы $safeprojectname$ ---");

app.ConfigureApplication();

app.Run();
