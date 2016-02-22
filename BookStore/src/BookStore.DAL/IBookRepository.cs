namespace BookStore.DAL
{
    using BookStore.Domain;

    public interface IBookRepository: IRepository<Book>
    {
        new bool Update(Book entity);
    }
}
