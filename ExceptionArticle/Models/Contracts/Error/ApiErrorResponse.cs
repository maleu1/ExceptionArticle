namespace ExceptionArticle.Models.Contracts.Error;

/// <summary>
/// API response containing errors
/// </summary>
public class ApiErrorResponse
{
    /// <summary>
    /// Gets errors collection.
    /// </summary>
    /// <value>
    /// The errors.
    /// </value>
    public ICollection<ApiError> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
    /// </summary>
    public ApiErrorResponse()
    {
        Errors = new List<ApiError>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public ApiErrorResponse(params ApiError[] errors)
    {
        Errors = new List<ApiError>(errors);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorResponse" /> class.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <exception cref="System.ArgumentNullException">errors</exception>
    public ApiErrorResponse(IEnumerable<ApiError> errors)
    {
        if (errors == null)
        {
            throw new System.ArgumentNullException(nameof(errors));
        }

        Errors = new List<ApiError>(errors);
    }
}
