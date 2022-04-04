using System.ComponentModel.DataAnnotations;

namespace PreezieCodingTask.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}
