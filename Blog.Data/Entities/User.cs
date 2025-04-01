using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Entities;
public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? PhotoUrl { get; set; }
    public List<Blog>? Blogs { get; set; } = new();
}
