using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryApp.Data;
using StoryApp.DTOs;
using StoryApp.Entities;
using static Azure.Core.HttpHeader;

namespace StoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController(DataContext _db,
            IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryDto>>> Story()
        {

            var stories = await _db.Stories.ToListAsync();
            var storiesDtos = _mapper.Map<IEnumerable<StoryDto>>(stories);
            return Ok(storiesDtos);

        }

        [HttpPost]
        public async Task<ActionResult<StoryDto>> Story([FromBody] StoryDto storyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            
            var story = _mapper.Map<Story>(storyDto);
            _db.Stories.Add(story);
            await _db.SaveChangesAsync();
            var responseStoryDto = _mapper.Map<StoryDto>(story);
            return Ok(responseStoryDto);
        }
    }
}
