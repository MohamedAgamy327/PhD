using API.DTO.User;
using Domain.Enums;
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

            RuleFor(x => x.Role)
                   .NotNull()
                   .NotEmpty()
                   .IsEnumName(typeof(RoleEnum));
        }
    }
}
