﻿namespace StoryApp.Entities
{
    public class Story : BaseEntity
    {
        public required string Tile { get; set; }
        public required string Body { get; set; }
        public required DateTime PublishedDate { get; set; }
    }
}
