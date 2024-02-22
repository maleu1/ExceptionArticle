
namespace ExceptionArticle.Validation;

/// <summary>
/// Error descriptor.
/// </summary>
public class ValidationError
{
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public Enum ErrorCode { get; set; }

    public IDictionary<string, object> MessageValues { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class.
    /// </summary>
    public ValidationError()
    {
        MessageValues = new Dictionary<string, object>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError" /> class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="messageValues">The message values to replace placeholders.</param>
    public ValidationError(Enum errorCode)
    {
        ErrorCode = errorCode;
        MessageValues = new Dictionary<string, object>();
    }
}