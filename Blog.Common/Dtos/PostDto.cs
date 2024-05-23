﻿namespace Blog.Common.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? FileUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorFullName { get; set; }
        public int BlogId { get; set; }
    }
}
