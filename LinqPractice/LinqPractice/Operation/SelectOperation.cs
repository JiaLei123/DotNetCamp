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

            //Simple Select first letter
            var result = from word in list
                         select (word as string).Substring(0, 1);
            PrintArray("Select first letter", result);

            var a_result = list.Select(p => p.Substring(0, 1));
            PrintArray("Lambda Select first letter", a_result);

            //select with formate result
            var result2 = from word in list
                         select string.Format("number is {0}", word);
            PrintArray("Select with formate result", result2);

            var a_result2 = list.Select(p => string.Format("number is {0}", p));
            PrintArray("Lambda Select with formate result", a_result2);

            //select with anonymity class
            var result3 = from word in list
                          select new { Name = word, lenght = word.Length };

            Console.WriteLine("Select word with word lenght" + ": ");
            int i = 0;
            foreach (var t in result3)
            {
                if (i < list.Count() - 1)
                {
                    Console.Write(t.Name + t.lenght + ", ");
                }
                else
                {
                    Console.Write(t.Name + t.lenght);
                }
                i++;
            }
            Console.WriteLine();


            var a_result3 =  list.Select(p=> new { Name = p, lenght = p.Length});

            Console.WriteLine("Lambda Select word with word lenght" + ": ");
            int j = 0;
            foreach (var t in a_result3)
            {
                if (i < list.Count() - 1)
                {
                    Console.Write(t.Name + t.lenght + ", ");
                }
                else
                {
                    Console.Write(t.Name + t.lenght);
                }
                j++;
            }
            Console.WriteLine();


            // select from multi collecton 
            var result1 = from words in slist
                          from word1 in (words as string).Split(' ')
                          select word1;
            PrintArray("Select words from statement", result1);

            //var a_result1 = slist.SelectMany(p)
        }
    }
}
