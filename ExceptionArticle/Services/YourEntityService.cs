using ExceptionArticle.Models;
using ExceptionArticle.Persistence.Repositories;
using ExceptionArticle.Validation;

namespace ExceptionArticle.Services;

public class YourEntityService : IYourEntityService
{
    private readonly IYourEntityRepository _repository;
    private readonly IMessageValidator<YourEntity> _entityValidator;
    
    public YourEntityService(IYourEntityRepository repository, IMessageValidator<YourEntity> entityValidator)
    {
        _repository = repository;
        _entityValidator = entityValidator;
    }

    /// <summary>
    /// Persists a new <see cref="YourEntity"/>.
    /// </summary>
    /// <param name="yourEntity">The entity to write to the DB.</param>
    /// <returns>The written entity.</returns>
    public async Task<YourEntity> CreateAsync(YourEntity yourEntity)
    {
        // too expensive!
        await _entityValidator.ValidateOrThrowAsync(yourEntity);
        
        // better :)
        //await _entityValidator.ValidateOrThrowAsync(yourEntity);
        
        return await _repository.AddEntity(yourEntity);
    }
}