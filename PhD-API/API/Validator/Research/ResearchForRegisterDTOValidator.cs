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

            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Entity)
            .NotNull()
            .NotEmpty();


            RuleFor(x => x.Address)
            .NotNull()
            .NotEmpty();


            RuleFor(x => x.FullTimeEmployeesNumber)
            .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PartTimeEmployeesNumber)
                  .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PhDResearchersNumber)
       .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MastersResearchersNumber)
                  .GreaterThanOrEqualTo(0);

            RuleFor(x => x.BachelorsResearchersNumber)
          .GreaterThanOrEqualTo(0);

            RuleFor(x => x.TechniciansNumber)
      .GreaterThanOrEqualTo(0);


        }
    }
}
