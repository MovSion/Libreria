using System.ComponentModel.DataAnnotations;

namespace Libreria.Dtos
{
    public class BookReadDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
    }
}