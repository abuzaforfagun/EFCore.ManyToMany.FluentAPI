using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.ManyToMany.FluentAPI
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookAuthor> BooksLink { get; set; }

    }
}
