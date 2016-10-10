using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynProgram
{
    abstract class DemoBase : IDemo
    {
        protected string subDemoType;

        public abstract void runDemo();

        protected static readonly Stopwatch Watch = new Stopwatch();

        protected static void printend()
        {
            Console.WriteLine($"Total use time：{Watch.ElapsedMilliseconds} milliseconds!!");
            Console.WriteLine($"==========================================================");

            Console.Read();
            Watch.Reset();
        }

        protected static void ExtraOperation(int id)
        {
            var s = "";

            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }

            Console.WriteLine($"id = {id}  ExtraOperation function wend：{Watch.ElapsedMilliseconds} ms");
        }
    }
}
