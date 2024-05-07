
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_9_OnlineStore_MVC.Controllers;

public class CategoryController : Controller
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _TagRepository;

    public CategoryController(ICategoryRepository categoryRepository, ITagRepository tagRepository)
    {
        _categoryRepository = categoryRepository;
        _TagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        bool exist = false;
        foreach (var item in await _categoryRepository.GetAllAsync())
        {
            if (item.Name == category.Name)
            {
                exist = true;
            }
        }
        if (!exist)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChanges();
            return RedirectToAction("GetAllCategory");
        }
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return View(categories);
    }

    [HttpGet]
    public async Task<IActionResult> AddTag(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        ViewBag.Tags = await _TagRepository.GetAllAsync();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddTag(int id, int[] tags)
    {
        var category = await _categoryRepository.GetByidWithTags(id);

        foreach (var tagId in tags)
        {
            var tag = await _TagRepository.GetByIdAsync(tagId);
            category.Tags.Add(tag);
        }

        await _categoryRepository.SaveChanges();
        return RedirectToAction("AddTag");
    }
}
