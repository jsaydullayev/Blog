using System.ComponentModel.DataAnnotations;

namespace Blog.Common.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string? FileUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string? AuthorFullName { get; set; }

        public Guid BlogId { get; set; }
        public string BlogName { get; set; }
    }

    public class CreatePostDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorFullName { get; set; }

        [Required]
        public Guid BlogId { get; set; }
    }

    public class UpdatePostDto
    {
        [StringLength(100)]
        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? AuthorFullName { get; set; }
    }
}
