using Microsoft.AspNet.Mvc;

namespace BookStore.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
