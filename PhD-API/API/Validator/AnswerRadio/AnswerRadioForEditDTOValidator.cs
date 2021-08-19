using API.DTO.AnswerRadio;
using FluentValidation;

namespace API.Validator.AnswerRadio
{
    public class AnswerRadioForEditDTOValidator : AbstractValidator<AnswerRadioForEditDTO>
    {
        public AnswerRadioForEditDTOValidator()
        {
            RuleFor(x => x.QuestionId)
                   .NotNull()
                   .NotEmpty();


            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

        }
    }
}
