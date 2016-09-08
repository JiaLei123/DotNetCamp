using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class OrderBy : LinqBase
    {
        public override IEnumerable<T> runLinq<T>(IEnumerable<T> list)
        {
            var result1 = from word in list
                         orderby (word as string).Length
                         select word;
            PrintArray(result1);


            var result = from word in list
                          orderby (word as string).Substring(0, 1) descending
                          select word;
            return result;
        }
    }
}
