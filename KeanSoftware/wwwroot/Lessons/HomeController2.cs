using Microsoft.AspNetCore.Mvc;

namespace KeanSoftware.wwwroot.Lessons
{
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
