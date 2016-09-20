using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynProgram
{
    class DemoFactory
    {
        public static IDemo Creat(string type)
        {
            IDemo result = null;
            switch(type)
            {
                case "-async":
                    result = new AsynFunction();
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}
