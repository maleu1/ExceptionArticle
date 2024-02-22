namespace ExceptionArticle.Models.Contracts.Error;

/// <summary>
/// Api error message parameters.
/// </summary>
public class ApiErrorParameter
{
    /// <summary>
    /// Gets or sets the parameter's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the parameter's value.
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorParameter"/> class.
    /// </summary>
    public ApiErrorParameter()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorParameter"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    /// <exception cref="ArgumentNullException">
    /// name
    /// or
    /// value
    /// </exception>
    public ApiErrorParameter(string name, object value)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}
