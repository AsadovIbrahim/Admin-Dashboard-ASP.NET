using Lesson_9_OnlineStore_Domain.Entities.Abstracts;

namespace Lesson_9_OnlineStore_Domain.Entities.Concretes;

public class Category : Entity
{
    public string? Name { get; set; }

    // Navigation Property
    public virtual ICollection<Tag> Tags { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
