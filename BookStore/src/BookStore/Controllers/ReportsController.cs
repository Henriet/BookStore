using Microsoft.AspNet.Mvc;

namespace BookStore.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
