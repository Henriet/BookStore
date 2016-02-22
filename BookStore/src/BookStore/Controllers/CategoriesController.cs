using Microsoft.AspNet.Mvc;

namespace BookStore.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // GET: Category/Edit/5
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
