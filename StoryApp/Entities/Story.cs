namespace StoryApp.Entities
{
    public class Story
    {
        public int Id { get; set; }
        public string Tile { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
