using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class LibreriaContext: DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> opt) : base(opt)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }
    }
}