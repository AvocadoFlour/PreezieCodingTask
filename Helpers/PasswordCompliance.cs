using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PreezieCodingTask.Helpers
{
    public class PasswordCompliance : ValidationAttribute
    {

        private readonly string regex = "(?=.*?[A-Z])(?=.*?[0-9]).{8,}";

        public PasswordCompliance()
            : base("The password must consist of at least 8 characters of which 1 is an upper case letter" +
                "and one a number.")
        {
        }

        //public override bool IsValid(object? value)
        //{
        //    var password = (string)value!;

        //    if(Regex.IsMatch(password, regex)){
        //        return true;
        //    }
        //    else return false;
        //}

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            var password = (string)value!;

            if (Regex.IsMatch(password, regex))
            {
                return ValidationResult.Success!;
            }
            else return new ValidationResult("The password must consist of at least 8 characters of which 1 is an upper case letter" +
                "and one a number.");
        }

    }
}
