using ExceptionArticle.Models.Contracts.Error;
using ExceptionArticle.Models.Enums;
using ExceptionArticle.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionArticle.ActionFilters;

/// <summary>
/// Handles uncaught <see cref="ValidationException"/> exceptions and converts them
/// to the BadRequest responses.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class ExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
{
    private const string UnhandledArgumentExceptionOccured = "Unhandled ArgumentException occured";
    private readonly ILogger _logger;

    /// <summary>
    /// Constructs a new instance of <see cref="ExceptionFilterAttribute"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    public ExceptionFilterAttribute(ILogger<ExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (!context.ExceptionHandled && context.Exception is ValidationException)
        {
            _logger.LogError(context.Exception, UnhandledArgumentExceptionOccured);

            // the caller will get the original exception message in the error description
            var apiErrorResponse = new ApiErrorResponse(
                new ApiError(ErrorCodes.InvalidRequestParameters.ToString(), context.Exception.Message));

            context.Result = new BadRequestObjectResult(apiErrorResponse);
            context.ExceptionHandled = true;
        }
    }
}
