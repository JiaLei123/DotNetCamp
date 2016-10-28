using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericityDemo
{
    public class MyHelp<T>
    {
        public T Name
        {
            get;
            set;
        }

        public static void Print(T t)
        {
            Console.WriteLine(t.ToString());
        }
    }
}
