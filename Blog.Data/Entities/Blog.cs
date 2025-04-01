using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User? User { get; set; }
        public List<Post> Posts { get; set; } = new();
    }
}
