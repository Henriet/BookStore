namespace BookStore.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using BookStore.Domain;

    public class BookRepository : Repository<Book>, IBookRepository
    {
        private IDbSet<Category> categoryObjectset;
        private IDbSet<Category> CategoryDbSet => this.categoryObjectset ?? (this.categoryObjectset = this.Context.Set<Category>());

        public new bool Update(Book book)
        {
            try
            {
                var bookFromDb = this.Get(book.Id);

                bookFromDb.Categories.Clear();

                foreach (var categoryFromDb in book.Categories.Select(category => this.CategoryDbSet.Find(category.Id)))
                {
                    bookFromDb.Categories.Add(categoryFromDb);
                }
                this.DbSet.Attach(bookFromDb);
                this.Context.Entry(bookFromDb).State = EntityState.Modified;
                this.CommitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}