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
            PrintArray("Original words in First String list are", list);

            List<string> slist = new List<string>();
            foreach (string a in Constants.examplewords1)
            {
                slist.Add(a);
            }
            result.Add(slist);
            PrintArray("Original words in Second String list are", slist);

            return result;
        }

        public override void runLinq(object obj)
        {
            List<IEnumerable<string>> lists = obj as List<IEnumerable<string>>;
            IEnumerable<string> list = lists[0];
            IEnumerable<string> list1 = lists[1];

            //从两个字符串列表中找到相同的字符串
            var result = from word in list
                         join word1 in list1 on word equals word1
                         select word;
            PrintArray("Select same words from two string array", result);

            var a_result = list.Join(list1, p => p.Length, s => s.Length, (p, s) => new { p, s});
            PrintArray("Select same words from two string array", a_result);

            var ab_result = list.Join(list1, p => p.Substring(0, 1), s => s.Substring(0, 1), (p, s) => new { p, s });
            PrintArray("Select same words from two string array", ab_result);
        }
    }
}
