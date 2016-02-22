using System.Collections.Generic;

namespace BookStore.Domain
{
    using System;
    using System.Text;

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public virtual List<Category> Categories { get; set; }
 
        public string CategoriesList
        {
            get
            {
                if(this.Categories == null || this.Categories.Count == 0)
                    return string.Empty;
                var categories = new StringBuilder();
                foreach (var category in this.Categories)
                {
                    categories.Append(category.Name);
                    categories.Append(" ");
                }
                return categories.ToString();
            }
        }
    }
}
