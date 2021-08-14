using API.DTO.AnswerMultiAmount;
using FluentValidation;

namespace API.Validator.AnswerMultiAmount
{
    public class AnswerMultiAmountForEditDTOValidator : AbstractValidator<AnswerMultiAmountForEditDTO>
    {
        public AnswerMultiAmountForEditDTOValidator()
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
