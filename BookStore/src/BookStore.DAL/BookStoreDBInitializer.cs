namespace BookStore.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BookStore.Domain;

    public class BookStoreDBInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            var poemsCategory = new Category { Name = "Poems", CreationDate = DateTime.Now };
            var fantasyCategory = new Category { Name = "Fantasy ", CreationDate = DateTime.Now };
            var detectiveCategory = new Category { Name = "Detective ", CreationDate = DateTime.Now };


            var MarkStrandBook = new Book { Author = "Mark Strand", Name = "The Story Of Our Lives", Categories = new List<Category> { poemsCategory, detectiveCategory }, ISBN = "1" };
            var EmilyBronteBook = new Book { Author = "Emily Bronte", Name = "Love and Friendship", Categories = new List<Category> { poemsCategory }, ISBN = "2" };
            var NancyAsireBook = new Book { Author = "Nancy Asire", Name = "To Fall Like Stars", Categories = new List<Category> { fantasyCategory }, ISBN = "3" };
            var ShirleeBusbeeBook = new Book { Author = "Shirlee Busbee", Name = "Swear by the Moon", Categories = new List<Category> { }, ISBN = "3" };

            poemsCategory.Books = new List<Book> { MarkStrandBook, EmilyBronteBook };
            detectiveCategory.Books = new List<Book> { MarkStrandBook };
            fantasyCategory.Books = new List<Book> { NancyAsireBook };

            context.Categories.AddRange(new List<Category>() { poemsCategory , detectiveCategory, fantasyCategory});
            context.Books.AddRange(new List<Book> { MarkStrandBook, EmilyBronteBook, NancyAsireBook, ShirleeBusbeeBook});
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
