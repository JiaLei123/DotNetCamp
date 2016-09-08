using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    public interface ILinq
    {
        IEnumerable<T> runLinq<T>(IEnumerable<T> list);
    }
}
