using API.DTO.AnswerCheckbox;
using FluentValidation;

namespace API.Validator.AnswerCheckbox
{
    public class AnswerCheckboxForEditDTOValidator : AbstractValidator<AnswerCheckboxForEditDTO>
    {
        public AnswerCheckboxForEditDTOValidator()
        {
            RuleFor(x => x.QuestionId)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.AnswerId)
                  .NotNull()
                  .NotEmpty();

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();


        }
    }
}
