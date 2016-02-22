namespace BookStore.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using BookStore.Domain;

    public class ReportModel
    { 
        public string CategoryName { get; set; }
        public int CountOfBooks { get; set; }

        public static List<ReportModel> GetReportModels(List<Book> books, List<Category> categories )
        {
            var models = categories.Select(category => new ReportModel { CategoryName = category.Name, CountOfBooks = category.Books?.Count ?? 0 }).ToList();

            var countOfBooksWithoutCategory = books.Count(book => book.Categories == null || book.Categories.Count == 0);
            if (countOfBooksWithoutCategory > 0)
                models.Add(new ReportModel {CountOfBooks = countOfBooksWithoutCategory , CategoryName = "[Unknown]" });
            
            return models;
        } 
    }
}
