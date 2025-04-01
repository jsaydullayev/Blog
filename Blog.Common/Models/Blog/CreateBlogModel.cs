using System.ComponentModel.DataAnnotations;

namespace Blog.Common.Models.Blog;
public class CreateBlogModel
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(500)]
    public required string Description { get; set; }
}
