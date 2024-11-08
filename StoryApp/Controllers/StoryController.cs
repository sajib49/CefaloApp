using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StoryApp.Commands;
using StoryApp.Data;
using StoryApp.DTOs;
using StoryApp.Entities;
using StoryApp.Helpers;
using StoryApp.Queries;

namespace StoryApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StoryController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly DataContext _db;
        private readonly ILogger<StoryController> _logger;
        public StoryController(
            IMapper mapper,
            IMediator mediator,
            ILoggerFactory loggerFactory,
            DataContext db)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger<StoryController>();
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryDto>>> Story()
        {

            var stories = await _db.Stories.ToListAsync();
            var storiesDtos = _mapper.Map<IEnumerable<StoryDto>>(stories);
            return Ok(storiesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoryDto>> GetStoryById([FromRoute] int id)
        {
            var query = new GetStoryQuery
            {
                Id = id
            };

            var story = await _mediator.Send(query);
            return Ok(story);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StoryDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StoryDto>> Story([FromBody] CreateStoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Validation Failed {modelState}", JsonConvert.SerializeObject(ModelState));
                return BadRequest("Invalid input");
            }

            var responseModel = await _mediator.Send(command);
            if (responseModel == null)
            {
                _logger.LogInformation($"Problem occured while adding story : {command.Tile}");
                return NotFound(); //TODO: not executed/created exception
            }

            return Created("Story has been created", responseModel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(StoryDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<StoryDto>> UpdateStoryAsync([FromBody] UpdateStoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Validation Failed {modelState}", JsonConvert.SerializeObject(ModelState));
                return BadRequest(ModelState);
            }
            var responseModel = await _mediator.Send(command);

            if (responseModel == null)
            {
                _logger.LogInformation($"Problem occured");
                return NotFound(); //TODO: not executed/created exception
            }

            return Ok(responseModel);            
        }

        [HttpDelete]
        [ProducesResponseType(typeof(StoryDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<StoryDto>> DeleteStoryAsync([FromBody] DeleteStoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Validation Failed {modelState}", JsonConvert.SerializeObject(ModelState));
                return BadRequest(ModelState);
            }
            var responseModel = await _mediator.Send(command);

            if (!responseModel)
            {
                _logger.LogInformation($"Problem occured");
                return NotFound(); //TODO: not executed/created exception
            }

            return Ok(responseModel);


        }
    }
}
