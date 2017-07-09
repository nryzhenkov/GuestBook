using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
