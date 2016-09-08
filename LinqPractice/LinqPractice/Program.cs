using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string>();
            foreach(string a in Constants.examplewords)
            {
                list.Add(a);
            }




            OrderBy show = new OrderBy();
            show.runDome(list);
        }
    }
}
