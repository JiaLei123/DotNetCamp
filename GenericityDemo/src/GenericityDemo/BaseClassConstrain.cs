using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericityDemo
{
    public class BaseClassConstrain<T> where T : User
    {
        public T User
        {
            get;
            set;
        }

        public void print()
        {
            User.addNickName();
            Console.WriteLine(User.Name.ToString());
        }
    }
}
