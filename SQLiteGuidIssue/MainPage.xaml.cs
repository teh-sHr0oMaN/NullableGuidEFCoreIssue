using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SQLiteGuidIssue.Model;

namespace SQLiteGuidIssue
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                using (var db = new BloggingContext())
                {
                    db.Database.Migrate();
                }

                using (var db = new BloggingContext())
                {
                    var data = (from blog in db.Blogs
                                join post in db.Posts on blog.BlogId equals post.BlogId
                                where post.Type == PostType.New
                                select blog).ToArray();

                    Blogs.ItemsSource = data;
                }
            };

            AddButton.Click += (sender, args) =>
            {
                using (var db = new BloggingContext())
                {
                    var blog = new Blog { BlogId = Guid.NewGuid(), Url = NewBlogUrl.Text, Posts = new List<Post>() };
                    blog.Posts.Add(new Post { PostId = Guid.NewGuid(), Title = "First", Type = PostType.New, BlogId = blog.BlogId });
                    blog.Posts.Add(new Post { PostId = Guid.NewGuid(), Title = "Last", Type = PostType.Reply, BlogId = blog.BlogId });

                    blog.Posts.Last().CopiedFromPostId = blog.Posts.First().PostId;

                    db.Blogs.Add(blog);

                    foreach (var post in blog.Posts)
                    {
                        db.Posts.Add(post);
                    }

                    db.SaveChanges();

                    Blogs.ItemsSource = db.Blogs.ToList();
                }

                NewBlogUrl.Text = string.Empty;
            };

            LoadButton.Click += (sender, args) =>
            {
                using (var db = new BloggingContext())
                {
                    var blogPosts = db.Posts.ToList();


                }
            };
        }
    }
}
