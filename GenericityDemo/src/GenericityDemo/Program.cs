using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericityDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Generictiy");

            User a = new User { Name = "txg378" };


            MyHelp<User> b = new MyHelp<User>();
            b.Name = a;

            MyHelp<User>.Print(b.Name);


            BusUser us = new BusUser() { Name = "txg378", ID = 123};
            BaseClassConstrain <BusUser> bus = new BaseClassConstrain<BusUser>();
            bus.User = us;
            bus.print();


            Console.ReadLine();
        }
    }
}
