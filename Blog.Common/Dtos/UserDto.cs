using System.ComponentModel.DataAnnotations;

namespace Blog.Common.Dtos
{
    public class UserDto
    {
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

        public List<BlogDto>? Blogs { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? PhotoUrl { get; set; }
    }

    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }

    public class UpdateUserDto
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Username { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }
    }
}
