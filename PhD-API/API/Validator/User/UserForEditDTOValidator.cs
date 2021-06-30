using API.DTO.User;
using FluentValidation;

namespace API.Validator.User
{
    public class UserForEditDTOValidator : AbstractValidator<UserForEditDTO>
    {
        public UserForEditDTOValidator()
        {
            RuleFor(x => x.Id)
                   .NotNull()
                   .NotEmpty();

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
