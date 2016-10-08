using ParameterParseUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynProgram
{
    class DemoFactory
    {
        public static IDemo Creat(Parameter param)
        {
            IDemo result = null;
            switch(param.ParameterType)
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
