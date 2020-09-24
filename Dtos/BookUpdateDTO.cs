using System.ComponentModel.DataAnnotations;

namespace Libreria.Dtos
{
    public class BookUpdateDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
    }
}