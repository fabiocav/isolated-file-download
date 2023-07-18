using HttpClientFactory.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsVsLive
{
    public class GreetingFunction
    {
        private readonly ILogger _logger;
        
        public GreetingFunction(ILogger<GreetingFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(GreetingFunction))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, CancellationToken cancellationToken)
        {
            if (req.Query.TryGetValue("name", out var nameValues))
            {
                var name = nameValues.FirstOrDefault();
                return new OkObjectResult(string.Format(Resources.PersonalGreeting, name));
            }

            return new OkObjectResult(Resources.GeneralGreeting);
        }
    }
}
