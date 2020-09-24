using System.Collections.Generic;
using Libreria.Models;

namespace Libreria.Data
{
    public class MockBooks : ILibreria
    {
        public void CreateBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var Books = new List<Book>{
                new Book{Id=0, Title="Hello World 1", Author="Pablo"},
                new Book{Id=1, Title="Hello World 2", Author="Pablo"},
                new Book{Id=2, Title="Hello World 3", Author="Pablo"}
            };
            return Books;
        }

        public Book GetBookById(int id)
        {
            return new Book{Id=0, Title="Hello World", Author="Pablo"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}