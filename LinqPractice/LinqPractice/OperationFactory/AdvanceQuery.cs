using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class AdvanceQuery : IFactory
    {
        public List<LinqBase> Create()
        {
            List<LinqBase> result = new List<LinqBase>();
            result.Add(new CollectionOperation());
            return result;
        }
    }
}
