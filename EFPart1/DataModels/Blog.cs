using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }

        public void AddBlog(Blog blog)
        {
            using (var context = new BloggingContext())
            {
                context.Blogs.Add(blog);                
                context.SaveChanges();
            }
        }
    }

}
