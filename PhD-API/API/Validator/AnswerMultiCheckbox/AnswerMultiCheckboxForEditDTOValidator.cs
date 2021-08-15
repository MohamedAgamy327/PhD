using API.DTO.AnswerMultiCheckbox;
using FluentValidation;

namespace API.Validator.AnswerMultiCheckbox
{
    public class AnswerMultiCheckboxForEditDTOValidator : AbstractValidator<AnswerMultiCheckboxForEditDTO>
    {
        public AnswerMultiCheckboxForEditDTOValidator()
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
