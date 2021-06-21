using API.DTO.Researcher;
using FluentValidation;

namespace API.Validator.Researcher
{
    public class ResearcherForRegisterDTOValidator : AbstractValidator<ResearcherForRegisterDTO>
    {
        public ResearcherForRegisterDTOValidator()
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
