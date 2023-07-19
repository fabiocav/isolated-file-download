using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsVsLive
{
    public class ClientFactoryFunction
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientFactoryFunction(ILogger<ClientFactoryFunction> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [Function(nameof(ClientFactoryFunction))]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving document...");

            using HttpClient client = _httpClientFactory.CreateClient(nameof(ClientFactoryFunction));

            var result = await client.GetStringAsync("functions-overview", cancellationToken);

            return new ContentResult
            {
                Content = result,
                ContentType = "text/html",
            };
        }
    }
}
