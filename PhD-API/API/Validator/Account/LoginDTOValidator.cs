using API.DTO.Account;
using FluentValidation;

namespace API.Validator.Account
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
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
