using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    class ExcecutionError : Exception
    {
        public ExcecutionError()
        {
            Console.WriteLine("\n~There was an error processing your request, please try again~\n");
        }
    }
}
