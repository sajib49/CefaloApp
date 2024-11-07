using MediatR;
using StoryApp.DTOs;

namespace StoryApp.Queries
{
    public class GetStoryQuery : IRequest<StoryDto>
    {
        public int Id { get; set; }
    }
}
