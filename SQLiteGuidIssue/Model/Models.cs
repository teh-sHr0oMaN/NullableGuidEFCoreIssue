using System;
using System.Collections.Generic;

namespace SQLiteGuidIssue.Model
{
    public enum PostType { New, Reply }

    public class Blog
    {
        public Guid BlogId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public Guid PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public PostType? Type { get; set; }

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; }

        public Guid? CopiedFromPostId { get; set; }
    }
}
