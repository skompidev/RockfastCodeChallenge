using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Rockfast.Infrastructure.Exceptions;
using System.Threading;

namespace Rockfast.Infrastructure.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            _logger.LogError("Error message: {exceptionMessage}", exception.Message);


            (string Title, string Detail, int StatusCode) details = exception switch
            {
                NotFoundException =>
                (
                    exception.GetType().Name,
                    exception.Message,
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound
                ),
                BadRequestException =>
                (
                    exception.GetType().Name,
                    exception.Message,
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                InternalServerException =>
                (
                    exception.GetType().Name,
                    exception.Message,
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
                ),
                _ =>
                (
                    exception.GetType().Name,
                    exception.Message,
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
                )
            };

            var problemDetails = new ProblemDetails
            {
                Type = details.Title,
                Title = details.Title,
                Status = details.StatusCode,
                Detail = details.Detail,
                Instance = context.HttpContext.Request.Path
            };

            await context.HttpContext.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
