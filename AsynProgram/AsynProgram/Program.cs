using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParameterParseUtility;
using System.Reflection;

namespace AsynProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = typeof(Program).Assembly;
            var types = a.GetTypes();
            var demoTypes = from type in types
                            where type.BaseType == typeof(AsyncDemoBase)
                            select type;

            List<Parameter> parameterList = ParameterParseUtility.ParameterParseUtility.ParseParameter(args);

            if (parameterList.Count != 1)
            {
                Console.WriteLine("No Prarameter, Please input correct paramete. the correct paramete are: AsynProgram: ");
                foreach(Type type in demoTypes)
                {
                    Console.Write($"-{type.Name} [");
                    var methods = type.GetMethods().Where(p => p.DeclaringType == type);
                    foreach(MethodInfo m in methods)
                    {
                        Console.Write($"{m.Name}|");
                    }
                    Console.WriteLine($"]");
                }
                return;
            }

            try
            {

                //var runMethods = from method in
                //                    from type in demoTypes
                //                    where type.Name.ToLower().StartsWith(parameterList[0].ParameterType.ToLower())
                //                    select type.GetMethods()
                //                where method.Name.ToLower().StartsWith(parameterList[0].ParameterString.ToLower())
                //                select method;
                var runTypes = from type in demoTypes
                               where type.Name.ToLower().StartsWith(parameterList[0].ParameterType.ToLower())
                               select type;
                var runType = runTypes.FirstOrDefault();

                var runMethods = from type in demoTypes
                                 where type.Name.ToLower().StartsWith(parameterList[0].ParameterType.ToLower())
                                 from method in type.GetMethods()
                                 where method.DeclaringType == type && method.Name.ToLower().StartsWith(parameterList[0].ParameterString.ToLower())
                                 select method;


                var runMethod = runMethods.FirstOrDefault();
                if (runType != null && runMethod != null)
                {
                    //runType.GetMethods();
                    ConstructorInfo cons = runType.GetConstructor(new Type[] {  });
                    object obj = cons.Invoke(null);
                    runMethod.Invoke(obj, null);
                }
            }
            catch
            {

            }
        }
    }
}
