using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFPart1
{
    class Menu
    {        
        private static Application application { get; set; }
        private static List<User> users = new List<User>();
        private static User user1 = new User();
        private static Parse parse = new Parse();        
        private static Dictionary<int, string> menuOptions; 
        public Menu(Application app)
        {
            application = app;
            users.Add(user1);
            menuOptions = new Dictionary<int, string>
        {
            {1, "Display Blogs"},
            {2, "Add Blog" },
            {3, "Display Posts" },
            {4, "Add Post" },
            {5, "Close Application" }
        };
            Print();
        }

        public void Print()
        {
            Console.WriteLine(menuOptions[1]);
            Console.WriteLine(menuOptions[2]);
            Console.WriteLine(menuOptions[3]);
            Console.WriteLine(menuOptions[4]);
            Console.WriteLine(menuOptions[5]);
            int option = ReadMenuOption();
            Execute(option);
        }

        public void Execute(int option)
        {            
            if(option == 1) 
            {
                DisplayBlogs();
            }
            else if (option == 2)
            {
                AddBlog();                
            }
            else if (option == 3)
            {
                DisplayPosts();
            }
            else if (option == 4)
            {
                AddPost();
            }
            else if(option == 5)
            {
                Console.WriteLine("\nGoodbye.");
                application.isRunning = false;
            }
            else
                {
                    try
                    {
                        throw new ExcecutionError();
                    }
                    catch (Exception e)
                    {
                        Print();
                        int i = ReadMenuOption();
                        Execute(i);                        
                    }
                }
            
        }

        private string ReadString()
        {
            string str = Console.ReadLine();
            if(str != "" || str != null)
            {
                return str;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int ReadMenuOption()
        {
            bool isInt = false;
            string input = Console.ReadLine();
            isInt = parse.parseInt(input);
            while (isInt == false)
            {
                input = Console.ReadLine();
                isInt = parse.parseInt(input);
            }
            int i = Convert.ToInt32(input);
            foreach(KeyValuePair<int, string> option in menuOptions)
            {
                if(i == option.Key)
                {
                    return i;
                }
                else
                {
                    
                }
            }
            try
            {
                throw new MenuOptionException();
            }
            catch(Exception e)
            {
                Print();
                int option = ReadMenuOption();
                Execute(option);
            }            
            return -1;            
        }

        private void AddBlog()
        {
            Console.WriteLine("Enter Blog Name");
            string name = Console.ReadLine();

            Blog blog = new Blog();
            blog.Url = "https://www.blogsblogsblogs.httpclient/.NET/" + name+"/";
            blog.AddBlog(blog);
            Console.WriteLine("Blog Added!: " + name);
        }

        private void DisplayBlogs()
        {
            using (var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine($"{blog.BlogId}: \t{blog.Url}");
                }
                Console.WriteLine();
            }
        }

        private void DisplayPosts()
        {
            using (var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine($"({blog.BlogId}){blog.Url}");
                }
            }
            bool isInt = false;
            string input = "";
            while (isInt == false)
            {
                Console.WriteLine("\nEnter Blog ID To Select: ");
                input = Console.ReadLine();
                isInt = parse.parseInt(input);
            }
            int b = Convert.ToInt32(input);
            using (var db = new BloggingContext())
            {
                try
                {                    
                    foreach(var post in db.Posts)
                    {
                        if(post.BlogId == b)
                        {
                            Console.WriteLine("\n" + post.Title + "\n------------\n" + post.Content + "\n\n");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n~Enter Valid Blog ID~\n");
                    DisplayPosts();
                }
            }
        }

        private void AddPost()
        {
            using (var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine($"({blog.BlogId}){blog.Url}");
                }
            }
            bool isInt = false;
            string input = "";
            while (isInt == false)
            {
                Console.WriteLine("\nEnter Blog ID To Select: ");
                input = Console.ReadLine();
                isInt = parse.parseInt(input);
            }
            int b = Convert.ToInt32(input);
            using(var db = new BloggingContext())
            {
                foreach(var blog in db.Blogs)
                {
                    if(b == blog.BlogId)
                    {
                        Console.WriteLine("Enter Title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Content:");
                        string content = Console.ReadLine();
                        Post post = new Post();
                        post.Title = title;
                        post.Content = content;
                        post.BlogId = blog.BlogId;
                        post.AddPost(post);
                        Console.WriteLine("Post Added!");
                    }
                    else
                    {
                        
                        AddPost();
                    }
                }
            }
        }
    }
}
