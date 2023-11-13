using System.Net;
using System.Text;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HttpDownload.HttpData
{
    public class Function
    {
        private const string BlobName = "dotnet-sdk-8.0.100-preview.6.23330.14-win-x64.exe";

        [Function("Function")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            [BlobInput($"runtimes/{BlobName}")] Stream blobStream)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/octet-stream");

            response.Body = blobStream;

            return response;
        }
    }
}
