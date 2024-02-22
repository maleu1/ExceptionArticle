namespace ExceptionArticle.Validation;

/// <summary>
/// Exception is raised if business validation has failed.
/// </summary>
public class ValidationException : Exception
{
    private readonly List<ValidationError> _validationErrors = new List<ValidationError>();

    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public ICollection<ValidationError> Errors => _validationErrors;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    public ValidationException()
    {
            
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="errors">Validation errors.</param>
    public ValidationException(ICollection<ValidationError> errors)
        : base(BuildErrorMessage(errors))
    {
        InitErrors(errors);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="errors">Validation errors.</param>
    public ValidationException(params ValidationError[] errors)
        : this(BuildErrorMessage(errors), errors)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="errors">The errors.</param>
    public ValidationException(string message, params ValidationError[] errors)
        : base(message)
    {
        InitErrors(errors);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="innerException">inner exception</param>
    /// <param name="errors">The errors.</param>
    public ValidationException(Exception innerException, params ValidationError[] errors)
        : base(BuildErrorMessage(errors), innerException)
    {
        if (errors != null)
        {
            _validationErrors.AddRange(errors);
        }
    }

    private void InitErrors(IEnumerable<ValidationError> errors)
    {
        if (errors != null)
        {
            _validationErrors.AddRange(errors);
        }
    }

    private static string BuildErrorMessage(ICollection<ValidationError> errors)
    {
        return errors.Count == 0
            ? string.Empty
            : "Validations failed: " + string.Join(", ", errors);
    }
}