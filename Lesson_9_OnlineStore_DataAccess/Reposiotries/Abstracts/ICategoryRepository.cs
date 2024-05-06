using Lesson_9_OnlineStore_Domain.Entities.Concretes;

namespace Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;

public interface ICategoryRepository:IGenericRepository<Category>
{
    Task<Category> GetByidWithTags(long id);
}
