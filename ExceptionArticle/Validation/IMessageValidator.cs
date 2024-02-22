using System.ComponentModel.DataAnnotations;

namespace ExceptionArticle.Validation;

/// <summary>
/// Message (command, query, event) validator.
/// </summary>
/// <typeparam name="TMessage">Message type.</typeparam>
public interface IMessageValidator<in TMessage>
{
    /// <summary>
    /// Validates the message (the good but expensive way).
    /// </summary>
    /// <param name="message">Message to validate.</param>
    Task ValidateOrThrowAsync(TMessage message);

    /// <summary>
    /// Validates the message (the better way).
    /// </summary>
    /// <param name="message">Message to validate.</param>
    /// <returns><see cref="ValidationResult"/> indicating the validation status.</returns>
    Task<ValidationResult> ValidateAsync(TMessage message);
}