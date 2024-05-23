﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Common.Models.Blog;
public class CreateBlogModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
}
