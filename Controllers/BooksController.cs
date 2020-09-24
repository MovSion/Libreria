using System.Collections.Generic;
using AutoMapper;
using Libreria.Data;
using Libreria.Dtos;
using Libreria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controllers
{
    // api/Books
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {
        private readonly ILibreria _mockLibreria;
        private readonly IMapper _mapper;
        public BooksController(ILibreria libreria, IMapper mapper)
        {
            _mockLibreria = libreria;
            _mapper = mapper;

        }
        
        // GET api/books  
        [HttpGet]
        public ActionResult<IEnumerable<BookReadDTO>> GetAllBooks()
        {
            var Books = _mockLibreria.GetAllBooks();
            return Ok(_mapper.Map<IEnumerable<BookReadDTO>>(Books));
        }

        // GET api/books/{id}
        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BookReadDTO> GetBookById(int id)
        {
            var Book = _mockLibreria.GetBookById(id);
            if(Book != null)
            {
                return Ok(_mapper.Map<BookReadDTO>(Book));
            }
            return NotFound();
        }

        //POST api/books
        [HttpPost]
        [Authorize]
        public ActionResult<BookReadDTO> CreateBook(BookReadDTO bookCreateDTO)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDTO);
            _mockLibreria.CreateBook(bookModel);
            _mockLibreria.SaveChanges();

            var bookReadDTO = _mapper.Map<BookReadDTO>(bookModel);

            return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDTO.Id}, bookReadDTO);
        }

        //PUT api/book/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, BookUpdateDTO bookToUpdate)
        {
            var bookModel = _mockLibreria.GetBookById(id);
            if(bookModel == null)
            {
                return NotFound();
            }
            _mapper.Map(bookToUpdate, bookModel);

            _mockLibreria.UpdateBook(bookModel);
            _mockLibreria.SaveChanges();

            return NoContent();
        }

        //PATCH api/books/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchBook(int id, JsonPatchDocument<BookUpdateDTO> itemToPatch)
        {
            var bookModel = _mockLibreria.GetBookById(id);
            if(bookModel == null)
            {
                return NotFound();
            }

            var bookToPatch = _mapper.Map<BookUpdateDTO>(bookModel);

            itemToPatch.ApplyTo(bookToPatch, ModelState);
            if(!TryValidateModel(bookToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(bookToPatch, bookModel);

            _mockLibreria.UpdateBook(bookModel);
            _mockLibreria.SaveChanges();

            return NoContent();
        }

        //DELETE api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var bookModel = _mockLibreria.GetBookById(id);
            if(bookModel == null)
            {
                return NotFound();
            }
            _mockLibreria.DeleteBook(bookModel);
            _mockLibreria.SaveChanges();

            return NoContent();
        }
    }
}