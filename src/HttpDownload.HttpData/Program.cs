using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
     .ConfigureServices(s =>
     {
         s.AddApplicationInsightsTelemetryWorkerService();
         s.ConfigureFunctionsApplicationInsights();
     })
    .Build();

host.Run();
