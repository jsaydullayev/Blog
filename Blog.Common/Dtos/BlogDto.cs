using System.ComponentModel.DataAnnotations;

namespace Blog.Common.Dtos
{
    public class BlogDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }

    public class CreateBlogDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }

    public class UpdateBlogDto
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
