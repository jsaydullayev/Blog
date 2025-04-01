using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public string? FileUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public required string AuthorFullName { get; set; }

        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
