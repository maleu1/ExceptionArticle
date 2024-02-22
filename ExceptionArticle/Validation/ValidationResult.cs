using System.Collections.ObjectModel;

namespace ExceptionArticle.Validation;

/// <summary>
/// Business logic validation result.
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// Gets the success validation result instance.
    /// </summary>
    /// <remarks>Immutable</remarks>
    public static ValidationResult Success { get; } = new ValidationResult(new ReadOnlyCollection<ValidationError>(new List<ValidationError>()));

    /// <summary>
    /// Creates a failed validation result.
    /// </summary>
    /// <param name="validationItems">Validation error items.</param>
    /// <returns>Failed validation result.</returns>
    /// <exception cref="ArgumentNullException">No validation errors are provided.</exception>
    public static ValidationResult Fail(params ValidationError[] validationItems)
    {
        if (validationItems == null || validationItems.Length == 0)
        {
            throw new ArgumentNullException(nameof(validationItems));
        }

        return new ValidationResult(validationItems);
    }
        
    /// <summary>
    /// Creates a failed validation result.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <returns>Failed validation result.</returns>
    public static ValidationResult Fail(Enum errorCode)
    {
        return new ValidationResult(new ValidationError(errorCode));
    }

    /// <summary>
    /// Gets a value indicating whether the validation result is successful.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this result is success; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuccessful => ValidationErrors.Count == 0;

    /// <summary>
    /// Gets validation errors.
    /// </summary>
    public ICollection<ValidationError> ValidationErrors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="validationErrors">Validation errors.</param>
    public ValidationResult(params ValidationError[] validationErrors)
    {
        ValidationErrors = new List<ValidationError>(validationErrors);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// For internal class use.
    /// </summary>
    /// <param name="validationErrors">The validation errors collection.</param>
    private ValidationResult(ICollection<ValidationError> validationErrors)
    {
        ValidationErrors = validationErrors;
    }

    /// <summary>
    /// Adds a validation error with the specified error code.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <returns>
    /// The added validation error.
    /// </returns>
    public ValidationError AddError(Enum errorCode)
    {
        var error = new ValidationError(errorCode);
        ValidationErrors.Add(error);

        return error;
    }

    /// <summary>
    /// Adds errors from another validation result instance.
    /// </summary>
    /// <param name="another">Another validation result to copy errors from.</param>
    public void AddFrom(ValidationResult another)
    {
        if (another.IsSuccessful)
        {
            return;
        }

        foreach (ValidationError error in another.ValidationErrors)
        {
            ValidationErrors.Add(error);
        }
    }

    /// <summary>
    /// Throws <see cref="ValidationException"/>, if validation is not successful.
    /// </summary>
    /// <exception cref="ValidationException" />
    public void ThrowIfValidationFailed()
    {
        if (!IsSuccessful)
        {
            throw new ValidationException(ValidationErrors);
        }
    }
}