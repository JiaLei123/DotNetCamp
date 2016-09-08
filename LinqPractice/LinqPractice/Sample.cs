using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Sample<T>
    {
        public T obj;
        public Sample(T obj)
        {
            this.obj = obj;
        }      
    }
}
