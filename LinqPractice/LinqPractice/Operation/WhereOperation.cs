using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class WhereOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            Console.WriteLine("Show Where: ");
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
                          where (word as string).Length == 3
                          select word;
            PrintArray("Filter the word's length is 3", result1);
        }
    }
}
