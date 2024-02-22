using ExceptionArticle.Models;

namespace ExceptionArticle.Services;

public interface IYourEntityService
{
    Task<YourEntity> CreateAsync(YourEntity yourEntity);
}