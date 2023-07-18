using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsVsLive
{
    public class DownloadFunction
    {
        private readonly ILogger _logger;

        public DownloadFunction(ILogger<DownloadFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(DownloadFunction))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var fileStream = File.OpenRead(@"C:\Users\facaval\Downloads\dotnet-sdk-6.0.406-win-x64.exe");

            return new FileStreamResult(fileStream, "application/octet-stream")
            {
                FileDownloadName = "dotnet-sdk-6.0.406-win-x64.exe"
            };
        }
    }
}
