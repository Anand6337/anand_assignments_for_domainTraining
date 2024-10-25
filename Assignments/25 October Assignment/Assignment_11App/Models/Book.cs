using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11App.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
        public Author Author { get; set; }

        public int AuthorId { get; set; }   
    }
}
