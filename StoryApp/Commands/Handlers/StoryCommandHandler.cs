﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoryApp.Data;
using StoryApp.DTOs;
using StoryApp.Entities;
using StoryApp.Queries.Handlers;


namespace StoryApp.Commands.Handlers
{
    public class StoryCommandHandler : IRequestHandler<CreateStoryCommand, StoryDto>,
        IRequestHandler<UpdateStoryCommand, UpdateStoryCommand>,
        IRequestHandler<DeleteStoryCommand, bool>
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<StoryQueryHandler> _logger;
        public StoryCommandHandler(
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

        public async Task<StoryDto> Handle(CreateStoryCommand command, CancellationToken cancellationToken)
        {
            var story = _mapper.Map<Story>(command);
            _db.Stories.Add(story);
            await _db.SaveChangesAsync();
            var responseStoryDto = _mapper.Map<StoryDto>(story);
            return responseStoryDto;
        }

        public async Task<UpdateStoryCommand> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {
            var story = _db.Stories.SingleOrDefault(x=> x.Id == request.Id);
            _mapper.Map(request, story);

            _db.Update<Story>(story);
            var rowCount = await _db.SaveChangesAsync(cancellationToken);

            if (rowCount > 0)
            {
                return request;
            }

            return null;
        }

        public async Task<bool> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            //CREATE PROCEDURE GetStoryById
            // @Id INT
            //AS
            //BEGIN

            //    select* from[dbo].[Stories]
            //            Where ID = @Id
            //END

            //EXEC GetStoryById @Id = 1

            //var IdParam = new SqlParameter("@Id", request.Id);
            //var stories =  _db.Stories.FromSqlRaw("EXEC GetStoryById @Id", IdParam).AsEnumerable().FirstOrDefault(); ;

            var story = await _db.Stories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (story == null)
            {
                throw new KeyNotFoundException($"Not found by Id: {request.Id}");
            }
            story.IsDeleted = true;
            _db.Update(story);
            var rowCount = await _db.SaveChangesAsync(cancellationToken);

            return rowCount > 0;
        }
    }
}
