using FluentValidation;
using StoryApp.DTOs;

namespace StoryApp.Validators
{
    public class CreateStoryValidator : AbstractValidator<StoryDto>
    {
        public CreateStoryValidator()
        {
            RuleFor(x => x.Body).NotNull().NotEmpty().WithMessage("Body should not empty");
            RuleFor(x => x.Tile).NotNull().NotEmpty().WithMessage("Title should not be empty");
            RuleFor(x => x.PublishedDate).NotNull().WithMessage("Published Date should not be empty");
        }
    }
}
