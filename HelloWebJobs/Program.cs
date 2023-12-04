using HelloWebJobs.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = new HostBuilder();

builder.ConfigureServices(services =>
{
    services.AddScoped<IHelloService, HelloService>();
})
.ConfigureLogging((context, b) =>
{
    b.AddConsole();
})
.ConfigureWebJobs(b =>
{
    b.AddAzureStorageCoreServices();
    b.AddAzureStorageBlobs();
    b.AddAzureStorageQueues(options => 
    {
        options.BatchSize = 10;
        options.MaxDequeueCount = 4;
        options.MaxPollingInterval = TimeSpan.FromSeconds(5);        
    });
})
.UseConsoleLifetime();

using var host = builder.Build();
await host.RunAsync();

