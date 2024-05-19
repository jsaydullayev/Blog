using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options): base(options)
        {
            
        }
        DbSet<User> Users { get; set; }
        DbSet<Entities.Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}
