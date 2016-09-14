using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class JoinOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            Console.WriteLine("Show Join Demo: ");

            List<IEnumerable<string>> result = new List<IEnumerable<string>>();

            List<string> list = new List<string>();
            foreach (string a in Constants.examplewords)
            {
                list.Add(a);
            }
            result.Add(list);
            PrintArray("original words are", list);

            List<string> slist = new List<string>();
            foreach (string a in Constants.examplewords1)
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
            IEnumerable<string> list1 = lists[1];

            var result = from word in list
                         join word1 in list1 on word equals word1
                         select word;

            PrintArray("Select same words from two string array", result);
        }
    }
}
