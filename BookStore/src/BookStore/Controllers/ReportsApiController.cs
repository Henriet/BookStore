using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using BookStore.Domain;

namespace BookStore.Controllers
{
    using BookStore.DAL;
    using BookStore.Models;

    [Produces("application/json")]
    [Route("api/Report")]
    public class ReportsApiController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IRepository<Category> categoryRepository;
        public ReportsApiController(IBookRepository bookRepository, IRepository<Category> categoryRepository)
        {
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
        }

        // GET: api/Report
        [HttpGet]
        public IEnumerable<ReportModel> GetReport()
        {
            var categories = this.categoryRepository.All();
            var books = this.bookRepository.All();

            return ReportModel.GetReportModels(books, categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.bookRepository.Dispose();
                this.categoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}