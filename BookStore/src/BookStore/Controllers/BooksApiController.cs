using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using BookStore.Domain;

namespace BookStore.Controllers
{
    using System;

    using BookStore.DAL;
    using Microsoft.AspNet.Authorization;
    [Produces("application/json")]
    [Route("api/Books")]
    [Authorize]
    public class BooksApiController : Controller
    {
        private readonly IBookRepository repository;
        private readonly IRepository<Category> categoryRepository;
        public BooksApiController(IBookRepository repository, IRepository<Category> categoryRepository)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBook()
        {
            return this.repository.All();
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }

            Book book = this.repository.Get(id);

            if (book == null)
            {
                return this.HttpNotFound();
            }

            return this.Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut]
        public IActionResult PutBook([FromBody] Book book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }
            try
            {
                this.repository.Update(book);
            }
            catch (Exception)
            {
                return this.HttpBadRequest();
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }
            try
            {
                this.repository.Insert(book);
            }
            catch (Exception)
            {
                return this.HttpBadRequest();
            }

            return this.CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpBadRequest(this.ModelState);
            }

            var book = this.repository.Get(id);
            if (book == null)
            {
                return this.HttpNotFound();
            }

            this.repository.Delete(id);

            return this.Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
                this.categoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}