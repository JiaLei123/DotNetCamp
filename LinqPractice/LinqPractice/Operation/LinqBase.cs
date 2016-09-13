using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    public abstract class LinqBase : ILinq
    {
        public object Demodata;
        public abstract object prepareDemoData();
        public abstract void runLinq(object list);

        public void runDome()
        {
            Demodata = prepareDemoData();
            runLinq(Demodata);
        }

        protected void PrintArray<T>(string message, IEnumerable<T> list)
        {
            Console.WriteLine(message + ": ");
            int i = 0;
            foreach (T t in list)
            {
                if (i < list.Count() - 1)
                {
                    Console.Write(t.ToString() + ", ");
                }
                else
                {
                    Console.Write(t.ToString());
                }
                i++;

            }
            Console.WriteLine();
        }


    }
}
