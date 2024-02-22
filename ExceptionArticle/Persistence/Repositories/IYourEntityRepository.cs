using ExceptionArticle.Models;

namespace ExceptionArticle.Persistence.Repositories;

public interface IYourEntityRepository
{
    Task<YourEntity> AddEntity(YourEntity yourEntity);
}