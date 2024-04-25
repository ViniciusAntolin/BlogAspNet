using Blog.Models;
using BlogEFFluentMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Interface
{
    public interface IDbContext
    {
        public DbSet<CategoryResult> Categories { get; set; }
        public DbSet<PostResult> Posts { get; set; }
        public DbSet<UserResult> Users { get; set; }
        public DbSet<PostWithTagsCountResult> PostsWithTags { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
