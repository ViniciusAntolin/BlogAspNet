using Blog.Models;
using BlogEFFluentMapping.Data.Mappings;
using BlogEFFluentMapping.Models;
using Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext, IDbContext
    {
        public DbSet<CategoryResult> Categories { get; set; }
        public DbSet<PostResult> Posts { get; set; }
        public DbSet<UserResult> Users { get; set; }
        public DbSet<PostWithTagsCountResult> PostsWithTags { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(@"Server=localhost, 1433; Database=Blog; User ID=sa; Password=Sync1004inova; trustServerCertificate=true");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Entity<PostWithTagsCountResult>(x => x.ToSqlQuery("select [Title] as Name, count(t.id) as Count from Post p inner join posttag pt on pt.postid = p.id inner join tag t on t.id = pt.tagid group by p.title").HasNoKey());
            base.OnModelCreating(modelBuilder);
        }
    }
}
