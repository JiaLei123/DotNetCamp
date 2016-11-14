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
            Console.WriteLine("Show Order By: ");
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

            //simply orderby
            var result1 = from word in list
                          orderby (word as string).Length
                          select word;
            PrintArray("Sort words by length", result1);

            var a_result1 = list.OrderBy(p => p.Length);
            PrintArray("Lambda Sort words by length", a_result1);


            //descending orderby
            var result2 = from word in list
                          orderby (word as string).Substring(0, 1) descending
                          select word;
            PrintArray("Sort words by first letter descending", result2);

            var a_result2 = list.OrderByDescending(p => p.Substring(0, 1));
            PrintArray("Lambda Sort words by first letter descending", a_result2);


            //order by two element
            var result3 = from word in list
                          orderby (word as string).Length, (word as string).Substring(0, 1)
                          select word;
            PrintArray("Sort words by length and the first letter", result3);

            var a_result3 = list.OrderBy(p => p.Length).ThenBy(s => s.Substring(0, 1));
            PrintArray("Lambda Sort words by length and the first letter", a_result3);

            //order by two element and descending
            var result = from word in list
                         orderby (word as string).Length, (word as string).Substring(0, 1) descending
                         select word;
            PrintArray("Sort words by length and the first letter descending", result);

            var a_result = list.OrderBy(p => p.Length).ThenByDescending(s => s.Substring(0, 1));
            PrintArray("Lambda Sort words by length and the first letter descending", a_result);

        }
    }
}
