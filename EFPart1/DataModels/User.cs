using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    class User
    {
        private List<Blog> blogs;
        private List<Post> posts;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int NumPosts { get; set; }
        public int NumBlogs { get; set; }

        public User()
        {
            blogs = new List<Blog>();
            posts = new List<Post>();
            NumPosts = posts.Count;
            NumBlogs = blogs.Count;
        }



        public void GetPosts(int postId)
        {
            
        }
    }
}
