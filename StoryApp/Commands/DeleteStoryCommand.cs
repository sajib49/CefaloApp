using MediatR;

namespace StoryApp.Commands
{
    public class DeleteStoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
