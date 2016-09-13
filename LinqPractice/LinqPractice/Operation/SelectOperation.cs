using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class SelectOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            Console.WriteLine("Show Selection: ");

            List<IEnumerable<string>> result = new List<IEnumerable<string>>();

            List<string> list = new List<string>();
            foreach (string a in Constants.examplewords)
            {
                list.Add(a);
            }
            result.Add(list);
            PrintArray("original words are", list);

            List<string> slist = new List<string>();
            foreach (string a in Constants.examplstatement)
            {
                slist.Add(a);
            }
            result.Add(slist);
            PrintArray("original words are", slist);

            return result;
        }

        public override void runLinq(object obj)
        {
            List<IEnumerable<string>> lists = obj as List<IEnumerable<string>>;
            IEnumerable<string> list = lists[0];
            IEnumerable<string> slist = lists[1];

            var result = from word in list
                         select (word as string).Substring(0, 1);
            PrintArray("Select first letter", result);      

            var result1 = from words in slist
                          from word1 in (words as string).Split(' ')
                          select word1;

            PrintArray("Select words from statement", result1);
        }
    }
}
