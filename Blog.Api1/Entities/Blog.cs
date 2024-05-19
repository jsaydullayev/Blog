using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
