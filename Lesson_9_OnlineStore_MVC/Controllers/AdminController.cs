using Microsoft.AspNetCore.Mvc;

namespace Lesson_9_OnlineStore_MVC.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}
