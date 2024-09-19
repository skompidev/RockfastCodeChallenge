using FluentValidation;

namespace Rockfast.ViewModels
{
    public record TodoVM(int Id, Guid UserId, string Name, DateTime? DateCompleted);

    public class TodoVMValidator : AbstractValidator<TodoVM>
    {
        public TodoVMValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Todo Name is required");
        }
    }
}