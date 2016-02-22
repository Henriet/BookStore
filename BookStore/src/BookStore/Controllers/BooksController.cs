using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // GET: Book/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.HttpNotFound();
            }
            
            return this.View(id);
        }
    }
}
