using ExceptionArticle.Models;

namespace ExceptionArticle.Validation;

public class EntityValidator : IMessageValidator<YourEntity>
{
    public Task ValidateOrThrowAsync(YourEntity message)
    {
        if (message.SomeValue <= 0)
        {
            throw new ValidationException("value may not be smaller than 1");
        }

        return Task.CompletedTask;
    }

    public Task<ValidationResult> ValidateAsync(YourEntity message)
    {
        if (message.SomeValue <= 0)
        {
            return Task.FromResult(ValidationResult.Fail(new ValidationError(ValidationErrorType.SomeExpectedError)));
        }

        return Task.FromResult(ValidationResult.Success);
    }
}