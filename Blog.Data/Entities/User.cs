using System.ComponentModel.DataAnnotations;

namespace Blog.Data
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
        public List<Entities.Blog>? Blogs { get; set; }
    }
}
