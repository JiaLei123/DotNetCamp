using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericityDemo
{
    public class User
    {
        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }

        public void addNickName()
        {
            Name = Name + " Yes";
        }
    }
}
