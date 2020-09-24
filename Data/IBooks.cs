using System.Collections.Generic;
using Libreria.Models;

namespace Libreria.Data
{
    public interface ILibreria
    {
         IEnumerable<Book> GetAllBooks();
         Book GetBookById(int id);

         bool ValidUser(User user);
         void CreateBook(Book book);
         bool SaveChanges();
         void UpdateBook(Book book);
         void DeleteBook(Book book);
    }
}