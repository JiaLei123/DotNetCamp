﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericityDemo
{
    public class BusUser : User
    {
        public int ID
        {
            get;
            set;
        }

        public void add<T>() where T: new()
        {
            Name = Name + " Yes";
        }
    }
}
