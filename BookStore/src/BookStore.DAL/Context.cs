using BookStore.Domain;
using System.Data.Entity;

namespace BookStore.DAL
{
    public class Context : DbContext
    {
        public Context()
            : base("Data Source=(LocalDb)\\v11.0;Initial Catalog=BookStore;Integrated Security=SSPI")
        //            : base("Server = tcp:bookstoretestproj.database.windows.net, 1433; Database=BookStoreTestProj_db;User ID = henriet@bookstoretestproj;Password=Books15!);Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;")

        {
            Database.SetInitializer(new BookStoreDBInitializer());
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(book => book.Books).WithMany(category => category.Categories);
            modelBuilder.Entity<Category>().HasMany<Book>(s => s.Books).WithMany(c => c.Categories);
            modelBuilder.Entity<Book>().Ignore(t => t.CategoriesList);
        }
    }
}
