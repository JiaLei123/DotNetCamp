using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("No Prarameter, Please input correct parameter, it inlcude: OrderBy, Where, Select.");
            }

            try
            {
                LinqBase demo = LinqService.getInstance().CreateLinq(args[0]);
                demo.runDome();
            }
            catch
            {
                Console.WriteLine("Error Prarameter, the support parameter only inlcude: OrderBy, Where, Select.");
            }  
        }
    }
}
