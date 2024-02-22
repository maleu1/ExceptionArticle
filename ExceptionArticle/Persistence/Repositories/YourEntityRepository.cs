using ExceptionArticle.Models;

namespace ExceptionArticle.Persistence.Repositories;

public class YourEntityRepository : IYourEntityRepository
{
    private List<YourEntity> _fakePersistenceLayer = new List<YourEntity>()
    {
        new YourEntity(1, "first", 4),
        new YourEntity(2, "second", 6),
        new YourEntity(3, "third", 2),
    };
    
    public async Task<YourEntity> AddEntity(YourEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        // here we would be adding the entity to the actual persistence layer.
        _fakePersistenceLayer.Add(entity);

        return entity;
    }
}