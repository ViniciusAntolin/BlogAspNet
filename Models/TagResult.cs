namespace Blog.Models
{
    public class TagResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<PostResult> Posts { get; set; }
    }
}
