using System.Collections.Generic;

namespace BookStore.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
