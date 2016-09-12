using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class GroupByOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            List<int> list = new List<int>();
            foreach (int a in Constants.exampleints)
            {
                list.Add(a);
            }
            PrintArray("original int list are", list);

            return list;
        }

        public override void runLinq(object obj)
        {
            IEnumerable<int> list = obj as IEnumerable<int>;
            var result = from number in list
                         group number by number % 2 == 0;

            foreach (var group in result)
            {
                PrintArray("Splite the Int Array to", group);
            }
        }
    }
}
