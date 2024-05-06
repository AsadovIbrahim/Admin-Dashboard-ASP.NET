using Microsoft.AspNetCore.Mvc;

namespace Lesson_9_OnlineStore_MVC.ViewComponents;

public class AdminDashboardNeworderViewComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
