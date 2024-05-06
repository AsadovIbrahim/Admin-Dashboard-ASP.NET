using Lesson_9_OnlineStore_DataAccess.Contexts;
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;

namespace Lesson_9_OnlineStore_DataAccess.Reposiotries.Concretes;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
