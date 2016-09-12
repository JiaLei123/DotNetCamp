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
                case Constants.orderby:
                    result = new OrderBy();
                    break;
                case Constants.where:
                    result = new WhereOperation();
                    break;
                case Constants.select:
                    result = new SelectOperation();
                    break;
                case Constants.groupby:
                    result = new GroupByOperation();
                    break;
                case Constants.covert:
                    result = new CaseOperation();
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}
