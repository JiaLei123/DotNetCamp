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

            if (!string.IsNullOrEmpty(paraString))
            {
                string[] paraml = paraString.Split(' ');
                result = ParseParameter(paraml);
            }

            return result;
        }


        public static List<Parameter> ParseParameter(string[] paraString)
        {
            List<Parameter> result = new List<Parameter>();
            if (paraString != null && paraString.Length > 0)
            {
                for(int i =0; i < paraString.Length;i++)
                {
                    string type = paraString[i];

                    if (type.StartsWith("-"))
                    {
                        if(paraString.Length > (i+1))
                        {
                            string value = paraString[i+1];
                            if(!value.StartsWith("-"))
                            {
                                Parameter para = new Parameter { ParameterType = type, ParameterString = value };
                                result.Add(para);
                                i++;
                            }
                            else
                            {
                                Parameter para = new Parameter { ParameterType = type, ParameterString = string.Empty };
                                result.Add(para);
                            }
                        }
                        else
                        {
                            Parameter para = new Parameter { ParameterType = type, ParameterString = string.Empty };
                            result.Add(para);
                        }
                    }
                }
            }


            return result;
        }
    }
}
