using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using BookStore.Domain;

namespace BookStore.Controllers
{
    using System;

    using BookStore.DAL;

    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesApiController : Controller
    {
        private readonly IRepository<Category> repository;

        public CategoriesApiController(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> GetCategory()
        {
            return this.repository.All();
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }

            var category = this.repository.Get(id);

            if (category == null)
            {
                return this.HttpNotFound();
            }

            return this.Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        public IActionResult PutCategory([FromBody] Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }
            try
            {
                var categoryFromDB = this.repository.Get(category.Id);
                if(categoryFromDB == null)
                    return this.HttpBadRequest();
                categoryFromDB.Name = category.Name;
                this.repository.Update(categoryFromDB);
            }
            catch (Exception)
            {
                return this.HttpBadRequest();
            }

            return this.Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult PostCategory([FromBody] string name)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }
            try
            {
                var category = new Category {Name = name, CreationDate = DateTime.Now};
                this.repository.Insert(category);
                //   return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
                return this.Ok(category);
            }
            catch (Exception)
            {
                return this.HttpBadRequest();
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }

            var category = this.repository.Get(id);
            if (category == null)
            {
                return this.HttpNotFound();
            }

            this.repository.Delete(id);

            return this.Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}