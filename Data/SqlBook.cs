using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Models;

namespace Libreria.Data
{
    public class SqlBook : ILibreria
    {
        private readonly LibreriaContext _context;

        public SqlBook(LibreriaContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            if(book == null){
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if(book == null){
                throw new ArgumentNullException(nameof(book));
            }
            _context.Books.Remove(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBook(Book book)
        {
            //Nothing
        }

        public bool ValidUser(User user)
        {
            var match = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (match.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}