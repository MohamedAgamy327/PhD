using API.DTO.AnswerNumber;
using FluentValidation;

namespace API.Validator.AnswerNumber
{
    public class AnswerNumberForEditDTOValidator : AbstractValidator<AnswerNumberForEditDTO>
    {
        public AnswerNumberForEditDTOValidator()
        {
            RuleFor(x => x.QuestionId)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.Number)
                  .NotNull()
                  .NotEmpty();

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

        }
    }
}
