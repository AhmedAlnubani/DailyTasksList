using FluentValidation;

namespace DailyTasksList.Application.Features.Taskes.Commands.CreatePost
{
    #region Public Class
    public class CreateCommandValidator: AbstractValidator<CreateTaskCommand>
    {
        #region Public Constructors
        public CreateCommandValidator() {

            RuleFor(p => p.Name)
             .NotEmpty()
             .NotNull();

            RuleFor(p => p.StartDate)
             .NotEmpty()
             .NotNull();

            RuleFor(p => p.DueDate)
             .NotEmpty()
             .NotNull();

        }
        #endregion Public Constructors
    }
    #endregion Public class
}
