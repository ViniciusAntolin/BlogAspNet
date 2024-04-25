namespace Blog.Models
{
    public class RoleResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<UserResult> Users { get; set; }
    }
}
