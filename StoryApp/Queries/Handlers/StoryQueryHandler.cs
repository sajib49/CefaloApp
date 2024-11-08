using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoryApp.Data;
using StoryApp.DTOs;

namespace StoryApp.Queries.Handlers
{
    public class StoryQueryHandler : IRequestHandler<GetStoryQuery, StoryDto>
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<StoryQueryHandler> _logger;

        public StoryQueryHandler(
          DataContext db,
          IMapper mapper,
          IMediator mediator,
          ILoggerFactory loggerFactory)

        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger<StoryQueryHandler>();
        }

        public async Task<StoryDto> Handle(GetStoryQuery request, CancellationToken cancellationToken)
        {
            var story = await _db.Stories.FirstOrDefaultAsync(x=> x.Id == request.Id && !x.IsDeleted);
            var storyDtos = _mapper.Map<StoryDto>(story);
            return storyDtos;
        }
    }
}
