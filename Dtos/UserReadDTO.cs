using System.ComponentModel.DataAnnotations;

namespace Libreria.Dtos
{
    public class UserReadDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}