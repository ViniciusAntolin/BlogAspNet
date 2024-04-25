namespace Blog.Models
{
    public class PostResult
    {
        public PostResult()
            => Tags = new List<TagResult>();

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Body { get; set; }
        public string? Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public CategoryResult Category { get; set; }
        public UserResult Author { get; set; }
        public List<TagResult> Tags { get; set; }
    }
}
