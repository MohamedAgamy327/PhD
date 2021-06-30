using API.DTO.User;
using FluentValidation;

namespace API.Validator.User
{
    public class UserForAddDTOValidator : AbstractValidator<UserForAddDTO>
    {
        public UserForAddDTOValidator()
        {
            RuleFor(x => x.Name)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.Email)
                  .NotNull()
                  .NotEmpty()
                  .EmailAddress();

        }
    }
}
