namespace BlazorChat.Models
{
    public class Newsfeed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string LinkToWeb { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
