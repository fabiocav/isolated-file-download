using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace FunctionsVsLive
{
    public class DownloadFunction
    {
        private const string BlobName = "dotnet-sdk-8.0.100-win-x64.exe";

        [Function(nameof(DownloadFunction))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
            [BlobInput($"runtimes/{BlobName}")] Stream blobStream)
        {
            return new FileStreamResult(blobStream, "application/octet-stream")
            {
                FileDownloadName = BlobName
            };
        }
    }
}
