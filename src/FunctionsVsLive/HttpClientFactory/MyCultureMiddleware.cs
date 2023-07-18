using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using System.Globalization;

public class MyCultureMiddleware : IFunctionsWorkerMiddleware
{
    public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var httpContext = context.GetHttpContext();

        if (httpContext != null && httpContext.Request.Query.TryGetValue("myculture", out var cultureValues))
        {
            var culture = cultureValues.Single() ?? "en-US";
            var cultureInfo = new CultureInfo(culture);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }

        return next(context);
    }
}