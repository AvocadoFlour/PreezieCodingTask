using System.ComponentModel.DataAnnotations;

namespace PreezieCodingTask.Helpers
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage = "Display name is required")]
        public string DisplayName { get; set; }

        [PasswordCompliance]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
