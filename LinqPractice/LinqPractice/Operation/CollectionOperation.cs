using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class CollectionOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            Console.WriteLine("Show Collection Operation By: ");
            PrintArray("original words are", Constants.examplewords_multi);

            return null;
        }

        public override void runLinq(object obj)
        {
            #region Distinct
            //fistly Distinct the query collection
            var result = from word in Constants.examplewords_multi.Distinct()
                         select word;

            PrintArray("Select Distinct from string array", result);

            //Distinct for result
            var result1 = (from word in Constants.examplewords_multi
                         select word).Distinct();

            PrintArray("Select Distinct from string array", result1);

            var result2 = (from word in Constants.examplewords_multi
                           select word);

            PrintArray("Select Distinct from string array", result2.Distinct());


            var list = Constants.examplewords_multi.Where(s => s.Length == 3).Distinct().OrderBy(r=>r.Substring(0,1));
            PrintArray("Select Distinct use lamada from string array", list);

            #endregion

            #region union

            #endregion 

        }
    }
}
