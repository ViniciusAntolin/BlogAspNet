using Blog.Models;
using BlogEFFluentMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Interface
{
    public interface IDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostWithTagsCount> PostsWithTags { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
