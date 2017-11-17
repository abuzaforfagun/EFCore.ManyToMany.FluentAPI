using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.ManyToMany.FluentAPI
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
        public BookAuthor()
        {
            
        }
    }
}
