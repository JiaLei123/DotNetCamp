using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No Prarameter, Please input correct paramete.");
                Console.WriteLine("the correct paramete are: AsynProgram:");
                Console.WriteLine("-async, -invoke, -thread");
            }

            try
            {
                IDemo a = DemoFactory.Creat(args[0]);
                a.runDemo();
            }
            catch
            {

            }
        }
    }
}
