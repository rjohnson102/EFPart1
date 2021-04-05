using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    class MenuOptionException : Exception
    {
        public MenuOptionException()
        {
            Console.WriteLine("\n~Selected option is not available~\n");                                 
        }
        
    }
}
