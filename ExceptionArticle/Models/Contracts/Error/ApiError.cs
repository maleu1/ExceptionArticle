namespace ExceptionArticle.Models.Contracts.Error;

/// <summary>
/// API error descriptor
/// </summary>
public class ApiError
{
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public string ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the error description.
    /// </summary>
    public string ErrorDescription { get; set; }

    /// <summary>
    /// Gets the error parameters: key - parameter name, value - parameter value.
    /// </summary>
    public List<ApiErrorParameter> ErrorParameters { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiError"/> class.
    /// </summary>
    public ApiError()
    {
        ErrorParameters = new List<ApiErrorParameter>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiError"/> class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="errorDescription">The localized error description.</param>
    /// <exception cref="System.ArgumentException">message - errorDescription</exception>
    public ApiError(string errorCode, string errorDescription)
        : this()
    {
        if (string.IsNullOrWhiteSpace(errorCode))
        {
            throw new ArgumentException("message", nameof(errorCode));
        }

        if (string.IsNullOrWhiteSpace(errorDescription))
        {
            throw new ArgumentException("message", nameof(errorDescription));
        }

        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
    }
}
