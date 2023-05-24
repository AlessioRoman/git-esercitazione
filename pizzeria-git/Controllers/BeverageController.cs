using Microsoft.AspNetCore.Mvc;

namespace pizzeria_git.Controllers
{
    public class BeverageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
