using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class OrderBy : LinqBase
    {
        public override object prepareDemoData()
        {
            List<string> list = new List<string>();
            foreach (string a in Constants.examplewords)
            {
                list.Add(a);
            }
            PrintArray("original words are", list);

            return list;
        }


        public override void runLinq(object obj)
        {
            IEnumerable<string> list = obj as IEnumerable<string>;

            var result1 = from word in list
                         orderby (word as string).Length
                         select word;
            PrintArray("Sort words by length", result1);

            var result2 = from word in list
                         orderby (word as string).Substring(0, 1) descending
                         select word;
            PrintArray("Sort words by first letter descending", result2);

            var result3 = from word in list
                          orderby (word as string).Length, (word as string).Substring(0, 1)
                          select word;
            PrintArray("Sort words by length and the first letter", result3);

            var result = from word in list
                          orderby (word as string).Length, (word as string).Substring(0, 1) descending
                          select word;
            PrintArray("Sort words by length and the first letter descending", result);
        }
    }
}
