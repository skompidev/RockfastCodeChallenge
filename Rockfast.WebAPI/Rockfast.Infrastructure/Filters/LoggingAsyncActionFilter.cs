using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.Infrastructure.Filters
{
    public class LoggingAsyncActionFilter : IAsyncActionFilter
    {
        private readonly ILogger _logger;
        public LoggingAsyncActionFilter(ILogger<LoggingAsyncActionFilter> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();
            var traceId = context.HttpContext.TraceIdentifier;
            _logger.LogInformation("Started Request Url: {url} InstanceId: {InstanceId}", url, traceId);
            var timer = new Stopwatch();
            timer.Start();

            await next();

            timer.Stop();
            if (timer.Elapsed.Seconds > 4)
                _logger.LogWarning("Performance Issue. Took {seconds}s for {url} InstanceId: {InstanceId}", timer.Elapsed.Seconds, url, traceId);

            _logger.LogInformation("Completed Request Url: {url} InstanceId: {InstanceId}", url, traceId);
        }
    }
}
