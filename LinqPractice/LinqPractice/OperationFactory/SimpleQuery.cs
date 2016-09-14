using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class SimpleQuery : IFactory
    {
        public List<LinqBase> Create()
        {
            List<LinqBase> result = new List<LinqBase>();
            result.Add(new OrderBy());
            result.Add(new WhereOperation());
            result.Add(new GroupByOperation());
            result.Add(new SelectOperation());
            result.Add(new CaseOperation());
            result.Add(new JoinOperation());
            return result;
        }
    }
}
