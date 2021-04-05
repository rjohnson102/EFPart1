using System;
using System.Collections.Generic;
using System.Text;

namespace EFPart1
{
    class Parse
    {
        public bool parseInt(string i)
        {
            try
            {
                Convert.ToInt32(i);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Option");
                return false;
            }
        }
    }
}
