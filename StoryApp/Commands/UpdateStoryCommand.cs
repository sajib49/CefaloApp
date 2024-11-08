using MediatR;
using StoryApp.DTOs;

namespace StoryApp.Commands
{
    public class UpdateStoryCommand : IRequest<UpdateStoryCommand>
    {
        public int Id { get; set; }
        public string Tile { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
