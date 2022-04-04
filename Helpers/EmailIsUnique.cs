﻿using PreezieCodingTask.Database;
using System.ComponentModel.DataAnnotations;

namespace PreezieCodingTask.Helpers
{
    public class EmailIsUnique : ValidationAttribute
    {

        private UsersContext _usersContext;

        public EmailIsUnique() 
            : base("The email addres is already registered or empty.")
        {
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var _usersContext = (UsersContext)validationContext
                         .GetService(typeof(IUsersContext))!;

            if (value == null)
                return new ValidationResult("Email address empty");

            if (!(_usersContext.Users.First(x => x.Email.Equals((string)value)) == null))
                return new ValidationResult("Email address already in use.");
            
            return ValidationResult.Success;
        }

    }
}
