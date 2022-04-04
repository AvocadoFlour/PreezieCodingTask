using PreezieCodingTask.Helpers;
using System.ComponentModel.DataAnnotations;

namespace PreezieCodingTask.Entities
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [EmailAddress]
        [EmailIsUnique]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [PasswordCompliance]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}
