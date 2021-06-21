using API.DTO.Research;
using FluentValidation;

namespace API.Validator.Research
{
    public class ResearchForRegisterDTOValidator : AbstractValidator<ResearchForRegisterDTO>
    {
        public ResearchForRegisterDTOValidator()
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
