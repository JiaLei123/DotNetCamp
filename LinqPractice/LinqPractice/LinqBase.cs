using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    abstract class LinqBase : ILinq
    {
        public void runDome<T>(IEnumerable<T> list)
        {
            PrintArray(list);
            var result = runLinq(list);
            PrintArray(result);
        }

        protected void PrintArray<T>(IEnumerable<T> list)
        {
            foreach(T t in list)
            {
                Console.Write(t.ToString() + ", ");
            }
            Console.WriteLine();
        }

        public abstract IEnumerable<T> runLinq<T>(IEnumerable<T> list);
    }
}
