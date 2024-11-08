using MediatR;
using StoryApp.DTOs;

namespace StoryApp.Commands
{
    public class CreateStoryCommand : IRequest<StoryDto>
    {
        public required string Tile { get; set; }
        public required string Body { get; set; }
        public required DateTime PublishedDate { get; set; }
    }
}
