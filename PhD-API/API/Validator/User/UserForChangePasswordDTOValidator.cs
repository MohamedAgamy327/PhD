using API.DTO.User;
using FluentValidation;

namespace API.Validator.User
{
    public class UserForChangePasswordDTOValidator : AbstractValidator<UserForChangePasswordDTO>
    {
        public UserForChangePasswordDTOValidator()
        {
            RuleFor(x => x.Id)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.Password)
                   .NotNull()
                   .NotEmpty()
                   .MinimumLength(6)
                   .Equal(x => x.ConfirmPassword)
                   .When(x => !string.IsNullOrWhiteSpace(x.Password));

            RuleFor(x => x.ConfirmPassword)
                   .NotNull()
                   .NotEmpty()
                   .MinimumLength(6);
        }

    }
}
