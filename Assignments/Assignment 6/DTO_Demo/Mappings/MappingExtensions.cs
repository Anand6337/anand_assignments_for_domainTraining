using DTO_Demo.DTO;
using DTO_Demo.Models;
using System.Runtime.CompilerServices;

namespace DTO_Demo.Mappings
{
    public static class MappingExtensions
    {
        //public static BookDTO ToDTO(this Book book)
        //{
        //    return new BookDTO
        //    {
        //        Id = book.Id,
        //        Title = book.Title,
        //        Author = book.Author,
        //        Price = book.Price,
        //    };
        //}

        //public static Book ToEntity(this BookDTO bookDTO)
        //{
        //    return new Book
        //    {
        //        Id = bookDTO.Id,
        //        Title = bookDTO.Title,
        //        Author = bookDTO.Author,
        //        Price = bookDTO.Price,
        //        //ReleaseDate = DateTime.Now,
        //        //Genre = "Comic"
        //    };
        //}

        //public static List<BookDTO> ToDTOList(this List<Book> books)
        //{
        //    //var bookDTOs = new List<BookDTO>();
        //    //foreach(var book in books)
        //    //{
        //    //    bookDTOs.Add(book.ToDTO());
        //    //}
        //    //return bookDTOs;
        //    return books.Select(book => book.ToDTO()).ToList();
        //}
    }
}
