﻿using API.DTO.User;
using FluentValidation;

namespace API.Validator.User
{
    public class UserForLoginDTOValidator : AbstractValidator<UserForLoginDTO>
    {
        public UserForLoginDTOValidator()
        {
            RuleFor(x => x.Email)
                   .NotNull()
                   .NotEmpty()
                   .EmailAddress();

            RuleFor(x => x.Password)
                   .NotNull()
                   .NotEmpty();
        }

    }
}
