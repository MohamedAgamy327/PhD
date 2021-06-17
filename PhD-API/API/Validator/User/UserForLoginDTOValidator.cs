using API.DTO.User;
using FluentValidation;

namespace API.Validator.User
{
    public class UserForLoginDTOValidator : AbstractValidator<UserForLoginDTO>
    {
        public UserForLoginDTOValidator()
        {
            RuleFor(x => x.Name)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.Password)
                   .NotNull()
                   .NotEmpty();
        }

    }
}
