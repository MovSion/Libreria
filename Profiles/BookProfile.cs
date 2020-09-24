
using AutoMapper;
using Libreria.Dtos;
using Libreria.Models;

namespace Libreria.Profiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookReadDTO>();
            CreateMap<BookReadDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<Book, BookUpdateDTO>();
        }
    }
}