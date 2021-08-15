using API.DTO.AnswerMultiPercentage;
using FluentValidation;

namespace API.Validator.AnswerMultiPercentage
{
    public class AnswerMultiPercentageForEditDTOValidator : AbstractValidator<AnswerMultiPercentageForEditDTO>
    {
        public AnswerMultiPercentageForEditDTOValidator()
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
