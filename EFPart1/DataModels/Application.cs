using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    class Application
    {
        public Menu menu { get; set; }
        public bool isRunning { get; set; }

        public Application()
        {
            isRunning = true;                      
        }

        public void Start(Application app)
        {
            menu = new Menu(app);            
        }

        public void Close()
        {
            isRunning = false;
        }
    }
}
