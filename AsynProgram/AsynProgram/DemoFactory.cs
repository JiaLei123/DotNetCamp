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
        public static IAsyncDemo Creat(Parameter param)
        {
            IAsyncDemo result = null;
            switch(param.ParameterType)
            {
                case "-async":
                    result = new Asyn(param.ParameterString);
                    break;
                case "-bgworker":
                    result = new bgWorker(param.ParameterString);
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}
