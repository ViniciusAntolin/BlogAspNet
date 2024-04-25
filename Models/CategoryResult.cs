namespace Blog.Models
{
    public class CategoryResult
    {
        public CategoryResult()
            => Posts = new List<PostResult>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<PostResult>? Posts { get; set; }
    }
}
