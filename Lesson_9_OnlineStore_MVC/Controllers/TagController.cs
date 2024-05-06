using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_9_OnlineStore_MVC.Controllers;

public class TagController : Controller
{
    private readonly ITagRepository _tagRepository;

    public TagController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult AddTag()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddTag(Tag tag)
    {
        await _tagRepository.AddAsync(tag);
        return View();
    }
}
