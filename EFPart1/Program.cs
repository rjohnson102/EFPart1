using System;

namespace EFPart1
{    
    class Program
    {
        public static Application app = new Application();
        static void Main(string[] args)
        {                      
            while (app.isRunning)
            {
                app.Start(app);
            }
            app.Close();                   
        }
    }
}
