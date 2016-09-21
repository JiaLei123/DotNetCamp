using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterParseUtility
{
    public class ParameterParseUtility
    {
        public static List<Parameter> ParseParameter(string paraString)
        {
            List<Parameter> result = new List<Parameter>();

            if(!string.IsNullOrEmpty(paraString))
            {
                string[] paraml = paraString.Split('-');
                if(paraml.Length > 0)
                {
                    foreach(string a in paraml)
                    {
                        if(!string.IsNullOrEmpty(a))
                        {
                            string[] aParam = a.Split(' ');
                            if (aParam.Length < 2)
                            {
                                Parameter param = new Parameter() { ParameterType = aParam[0], ParameterString = string.Empty };
                                result.Add(param);
                            }
                            else
                            {
                                Parameter param = new Parameter() { ParameterType = aParam[0], ParameterString = aParam[1] };
                                result.Add(param);
                            }

                        }

                    }
                    
                }
            }

            return result;
        }
    }
}
