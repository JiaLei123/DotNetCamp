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
                Console.WriteLine("No Prarameter, Please input correct paramete.");
                Console.WriteLine("the correct paramete are: LinqPractice:");
                Console.WriteLine("-s orderby|where|selece|covert|groupby|collection| ");
                Console.WriteLine("-g simple|adv ");
            }

            try
            {
                if(args[0] == "-s")
                {
                    LinqBase demo = LinqService.getInstance().CreateLinq(args[1]);
                    demo.runDome();
                }
                else
                {
                    List<LinqBase> demo = LinqService.getInstance().CreateLinqFactory(args[1]);
                    foreach (LinqBase cmd in demo)
                    {
                        cmd.runDome();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error Prarameter happened.");
            }  
        }
    }
}
