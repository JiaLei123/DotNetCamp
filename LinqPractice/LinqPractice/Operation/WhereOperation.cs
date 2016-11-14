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
            //simply where
            var result1 = from word in list
                          where (word as string).Length == 3
                          select word;
            PrintArray("Filter the word's length is 3", result1);

            var a_result1 = list.Where(p => p.Length == 3);
            PrintArray("Lambda Filter the word's length is 3", a_result1);

            //use contain and let in where state

            var result = from word in list
                         let i = word.Substring(0,1)
                         where Constants.examplewords1_firstLetter.Contains(i)
                         select word;
            PrintArray("Filter the word begin with: b, f, j", result);

            var a_result = list.Where(p => Constants.examplewords1_firstLetter.Contains(p.Substring(0,1)));
            PrintArray("Lambda Filter the word begin with: b, f, j", a_result);



        }
    }
}
