using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public void AddPost(Post post)
        {
            using (var context = new BloggingContext())
            {
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }
    }
}
