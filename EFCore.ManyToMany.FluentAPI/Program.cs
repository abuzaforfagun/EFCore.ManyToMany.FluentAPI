using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.ManyToMany.FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book()
            {
                Name = "Book 1",
                Price = 100
            };
            Author a1 = new Author()
            {
                Name = "Author 1"
            };

            b1.AuthorsLink = new List<BookAuthor>
            {
                new BookAuthor
                {
                    Author=a1,
                    Book=b1
                }
            };

            ApplicationDbContext context = new ApplicationDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Books.Add(b1);
            context.SaveChanges();
            var bookList = context.Books.ToList();
            Console.WriteLine("Adding book object...");
            foreach(var b in bookList)
            {
                Console.WriteLine("Id#{0} | Name: {1}", b.Id, b.Name);
                Console.WriteLine("Authors:");
                foreach(var a in b.AuthorsLink)
                {
                    Console.WriteLine(a.Author.Name);
                }
            }

            Console.WriteLine("Adding new authorin book 1");
            Author a2 = new Author
            {
                Name = "Author 2"
            };
            
            var b1FromDb = context.Books.Include(b => b.AuthorsLink).Single(b => b.Id == 1);
            b1FromDb.AuthorsLink.Add(
                new BookAuthor
                {
                    Book = b1FromDb,
                    Author = a2
                });
            context.SaveChanges();
            bookList = context.Books.ToList();
            foreach (var b in bookList)
            {
                Console.WriteLine("Id#{0} | Name: {1}", b.Id, b.Name);
                Console.WriteLine("Authors:");
                foreach (var a in b.AuthorsLink)
                {
                    Console.WriteLine(a.Author.Name);
                }
            }

            Console.WriteLine("Removing old author and add new one...");
            Author a3 = new Author
            {
                Name = "Author 3"
            };
            var b2FromDb = context.Books.Include(b => b.AuthorsLink).Single(b => b.Id == 1);
            b1FromDb.AuthorsLink = new List<BookAuthor>
            {
                new BookAuthor
                {
                    Book=b1FromDb,
                    Author=a3
                }
            };
            context.SaveChanges();
            bookList = context.Books.ToList();
            foreach (var b in bookList)
            {
                Console.WriteLine("Id#{0} | Name: {1}", b.Id, b.Name);
                Console.WriteLine("Authors:");
                foreach (var a in b.AuthorsLink)
                {
                    Console.WriteLine(a.Author.Name);
                }
            }
            
        }
    }
}
