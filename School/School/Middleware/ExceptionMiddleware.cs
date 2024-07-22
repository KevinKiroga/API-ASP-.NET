using School.Modules.Student.BO.Exceptions;
using System.Net;

namespace School.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                UnauthorizedAccessException => (int)HttpStatusCode.Forbidden,
                ArgumentNullException => (int)HttpStatusCode.BadRequest,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                AppException => (int)HttpStatusCode.InternalServerError,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            string statusError = string.Empty;
            string message = exception.Message;
            bool isErrorLog = true;
            bool writeToLog = true;

            var err = new ErrorResponse(statusError,
                            message,
                            new string[] { exception.InnerException?.Message ?? string.Empty });

            if (writeToLog)
            {
                if (isErrorLog) _logger.LogError(exception, err.ToString());
                else _logger.LogInformation(err.ToString());
            }

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(err.ToString());
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
    }
}
