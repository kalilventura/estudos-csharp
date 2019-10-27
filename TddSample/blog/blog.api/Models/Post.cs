using System;

namespace blog.api.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}