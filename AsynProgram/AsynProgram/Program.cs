using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParameterParseUtility;

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
                Console.WriteLine("-async [simple|], -invoke[], -thread[], -bgworker[process|cancel]");
            }

            try
            {
                List<Parameter> parameterList = ParameterParseUtility.ParameterParseUtility.ParseParameter(args);
                if(parameterList.Count == 1)
                {
                    IDemo a = DemoFactory.Creat(parameterList[0]);
                    a.runDemo();
                }
                else
                {
                    Console.WriteLine("wrong Prarameter format, Please input correct paramete.");
                    Console.WriteLine("the correct paramete are: AsynProgram:");
                    Console.WriteLine("-async [simple|], -invoke[], -thread[], -bgworker[process|cancel]");
                }

            }
            catch
            {

            }
        }
    }
}
