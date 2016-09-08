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
                Console.WriteLine("No Prarameter, Please input correct parameter, it inlcude: OrderBy, ");
            }

            List<string> list = new List<string>();
            foreach(string a in Constants.examplewords)
            {
                list.Add(a);
            }

            try
            {
                LinqBase demo = LinqService.getInstance().CreateLinq(args[0]);
                demo.runDome(list);
            }
            catch
            {
                Console.WriteLine("Error Prarameter, the support parameter only inlcude: OrderBy, ");
            }
            
        }
    }
}
