using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class LinqService
    {
        private LinqService(){}

        private static LinqService instance = new LinqService();

        public static LinqService getInstance()
        {
            return instance;
        }

        public LinqBase CreateLinq(string name)
        {
            string cmd = name.ToLower().Trim();
            LinqBase result;
            switch (cmd)
            {
                case "orderby":
                    result = new OrderBy();
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}
