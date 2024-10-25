using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using Assignment_11App.Models;

namespace BookAuthorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "J.K. Rowling", Country = "United Kingdom" },
                new Author { AuthorId = 2, Name = "George R.R. Martin", Country = "United States" },
                new Author { AuthorId = 3, Name = "Haruki Murakami", Country = "Japan" },
                new Author { AuthorId = 4, Name = "Jane Austen", Country = "United Kingdom" },
                new Author { AuthorId = 5, Name = "Mark Twain", Country = "United States" }
            };

            var books = new List<Book>
            {
                new Book { BookId = 1, Title = "Harry Potter", Genre = "Fantasy", AuthorId = 1 },
                new Book { BookId = 2, Title = "Game of Thrones", Genre = "Fantasy", AuthorId = 2 },
                new Book { BookId = 3, Title = "Norwegian Wood", Genre = "Fiction", AuthorId = 3 },
                new Book { BookId = 4, Title = "Pride and Prejudice", Genre = "Romance", AuthorId = 4 },
                new Book { BookId = 5, Title = "Adventures of Huckleberry Finn", Genre = "Adventure", AuthorId = 5 }
            };

            // Serialize to JSON
            string authorsJson = JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true });
            string booksJson = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON to file
            File.WriteAllText("authors.json", authorsJson);
            File.WriteAllText("books.json", booksJson);

            // Serialize to XML
            var authorXmlSerializer = new XmlSerializer(typeof(List<Author>));
            var bookXmlSerializer = new XmlSerializer(typeof(List<Book>));

            using (var authorStream = new StreamWriter("authors.xml"))
            {
                authorXmlSerializer.Serialize(authorStream, authors);
            }

            using (var bookStream = new StreamWriter("books.xml"))
            {
                bookXmlSerializer.Serialize(bookStream, books);
            }

            // Read and display JSON data
            Console.WriteLine("Authors (JSON):");
            Console.WriteLine(File.ReadAllText("authors.json"));

            Console.WriteLine("\nBooks (JSON):");
            Console.WriteLine(File.ReadAllText("books.json"));

            // Read and display XML data
            Console.WriteLine("\nAuthors (XML):");
            Console.WriteLine(File.ReadAllText("authors.xml"));

            Console.WriteLine("\nBooks (XML):");
            Console.WriteLine(File.ReadAllText("books.xml"));
        }
    }
}
