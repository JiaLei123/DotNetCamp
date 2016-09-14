using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class CaseOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            Console.WriteLine("Show Case Date Type: ");
            var plants = new Plant[]
            {
                new CarnivorousPlant { Name = "Venus Fly Trap", TrapType = "Snap Trap" },
                new CarnivorousPlant { Name = "Pitcher Plant", TrapType = "Pitfall Trap" },
                new CarnivorousPlant { Name = "Sundew", TrapType = "Flypaper Trap" },
                new CarnivorousPlant { Name = "Waterwheel Plant", TrapType = "Snap Trap" }
           };

            return plants;
        }

        public override void runLinq(object obj)
        {
            IEnumerable<Plant> list = obj as IEnumerable<Plant>;
            var result = from CarnivorousPlant a in list
                         where a.TrapType == "Snap Trap"
                         select a;
            PrintArray("Demo thow the case the data type", result);
        }

        class Plant
        {
            public string Name { get; set; }

            public override string ToString()
            {
                return this.Name;
            }
        }

        class CarnivorousPlant : Plant
        {
            public string TrapType { get; set; }
        }
    }
}
