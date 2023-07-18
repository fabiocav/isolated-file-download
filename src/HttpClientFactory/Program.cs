using FunctionsVsLive;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(builder =>
    {
        builder.UseMiddleware<MyCultureMiddleware>();
    })
    .ConfigureServices(services =>
    {
        services.AddHttpClient(nameof(ClientFactoryFunction),
            client =>
            {
                client.DefaultRequestHeaders.AcceptLanguage.Add(new(CultureInfo.CurrentUICulture.Name));
                client.BaseAddress = new Uri("https://learn.microsoft.com/azure/azure-functions/");
            });
    })
    .Build();

host.Run();
