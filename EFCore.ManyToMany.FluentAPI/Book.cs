using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.ManyToMany.FluentAPI
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<BookAuthor> AuthorsLink { get; set; }
    }
}
