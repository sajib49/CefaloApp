using AutoMapper;
using StoryApp.DTOs;
using StoryApp.Entities;

namespace StoryApp
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<StoryDto, Story>().ReverseMap();
            });
        }

    }
}
