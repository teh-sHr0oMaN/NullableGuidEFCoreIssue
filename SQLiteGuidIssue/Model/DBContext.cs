using Microsoft.EntityFrameworkCore;

namespace SQLiteGuidIssue.Model
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Filename=blog.db;Cache=Shared";
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
