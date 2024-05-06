using Lesson_9_OnlineStore_DataAccess.Contexts;
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Lesson_9_OnlineStore_DataAccess.Reposiotries.Concretes;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<Category> GetByidWithTags(long id)
    {
        return await _context.Categories.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
    }
}   

